#region Using References

using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

#endregion

namespace Hadoken.Data.Migrations
{
    public class MigrationRunner
    {
        static MigrationRunner()
        {
            _assembly = Assembly.GetAssembly(typeof(Migration));
        }

        public MigrationRunner(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        private readonly DbConnection _dbConnection;

        private static readonly Assembly _assembly;

        private const string MigrationSchemaName = "Migration";
        private const string MigrationTableName = "State";

        private int BumpMigrationState()
        {
            using (DbCommand dbCommand = CommandFactory.NewTextCommand(_dbConnection, $"INSERT INTO {MigrationSchemaName}.{MigrationTableName} (Value) SELECT (COALESCE(MAX(Value), 0) + 1) FROM {MigrationSchemaName}.{MigrationTableName};"))
            {
                dbCommand.ExecuteNonQuery();
            }

            return GetMigrationState();
        }

        private void CheckDatabase()
        {
            if (_dbConnection != null)
            {
                if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }

                CreateMigrationSchema();
                CreateMigrationTable();
            }
        }

        private void CreateMigrationSchema()
        {
            using (DbCommand dbCommand = CommandFactory.NewTextCommand(_dbConnection, $"CREATE SCHEMA IF NOT EXISTS {MigrationSchemaName} AUTHORIZATION postgres;"))
            {
                dbCommand.ExecuteNonQuery();
            }
        }

        private void CreateMigrationTable()
        {
            using (DbCommand dbCommand = CommandFactory.NewTextCommand(_dbConnection))
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine($"DROP TABLE IF EXISTS {MigrationSchemaName}.{MigrationTableName};");

                stringBuilder.AppendLine($"CREATE TABLE IF NOT EXISTS {MigrationSchemaName}.{MigrationTableName}");
                stringBuilder.AppendLine("(");
                stringBuilder.AppendLine("    ID serial NOT NULL PRIMARY KEY,");
                stringBuilder.AppendLine("    Value integer NOT NULL,");
                stringBuilder.AppendLine("    DateTime timestamp without time zone NOT NULL DEFAULT(now() at time zone 'utc')");
                stringBuilder.AppendLine(")");
                stringBuilder.AppendLine("WITH(OIDS = FALSE);");

                stringBuilder.AppendLine($"ALTER TABLE {MigrationSchemaName}.{MigrationTableName} OWNER TO postgres;");

                dbCommand.CommandText = stringBuilder.ToString();
                dbCommand.ExecuteNonQuery();
            }
        }

        public void ExecuteMigrations()
        {
            CheckDatabase();

            int migrationState = GetMigrationState();

            List<Migration> migrations = new List<Migration>();

            _assembly.GetExportedTypes()
                .Where(m =>
                (
                    (m.BaseType == typeof(Migration)) &&
                    (m.GetCustomAttributes().Select(n => (n.GetType())).Contains(typeof(MigrationAttribute)) == true)
                ))
                .ToList()
                .ForEach(m => migrations.Add((Migration)(_assembly.CreateInstance(m.FullName))));

            foreach (Migration migration in migrations.Where(m => (m != null)))
            {
                MigrationAttribute migrationAttribute = migration.GetType().GetCustomAttributes().OfType<MigrationAttribute>().FirstOrDefault();

                if ((migrationAttribute.Value > migrationState) && (migrationAttribute.IsIgnore == false))
                {
                    try
                    {
                        migration.Apply();

                        migrationState = BumpMigrationState();
                    }
                    catch
                    {
                        migration.Rollback();

                        throw;
                    }
                }
            }
        }

        private int GetMigrationState()
        {
            int getMigrationState = 0;

            using (DbCommand dbCommand = CommandFactory.NewTextCommand(_dbConnection, $"SELECT COALESCE(MAX(Value), 0) AS Value FROM {MigrationSchemaName}.{MigrationTableName};"))
            {
                using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                {
                    while (dbDataReader.Read() == true)
                    {
                        getMigrationState = Convert.ToInt32(dbDataReader["Value"]);
                    }
                }
            }

            return getMigrationState;
        }
    }
}
