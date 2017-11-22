#region Using References

using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

using Hadoken.Core.IO;

#endregion

namespace Hadoken.Data.Migrations
{
    public class MigrationRunner : IDisposable
    {
        static MigrationRunner()
        {
            _assembly = Assembly.GetAssembly(typeof(Migration));
        }

        public MigrationRunner(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        private static DbConnection _dbConnection;

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

        public void Dispose()
        {
            if (_dbConnection != null)
            {
                if (_dbConnection.State != ConnectionState.Closed)
                {
                    _dbConnection.Close();
                }

                _dbConnection.Dispose();
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

            migrations = migrations.Where(m => (m != null)).ToList();

            OutputStreams.WriteLine($"Found {migrations.Count} migrations.");

            foreach (Migration migration in migrations)
            {
                MigrationAttribute migrationAttribute = migration.GetType().GetCustomAttributes().OfType<MigrationAttribute>().FirstOrDefault();

                OutputStreams.WriteLine($"Found migration {migrationAttribute.Value}");

                if ((migrationAttribute.Value > migrationState) && (migrationAttribute.IsIgnore == false))
                {
                    try
                    {
                        OutputStreams.WriteLine($"Applying migration {migrationAttribute.Value}...");

                        migration.Apply();

                        migrationState = BumpMigrationState();
                    }
                    catch
                    {
                        migration.Rollback();

                        throw;
                    }
                }
                else
                {
                    OutputStreams.WriteLine($"Skipping migration {migrationAttribute.Value}...");
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

        internal static void ExecuteResource(string name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                using (StreamReader streamReader = new StreamReader(_assembly.GetManifestResourceStream($"Hadoken.Data.Migrations.{name}")))
                {
                    string resource = streamReader.ReadToEnd();

                    if (String.IsNullOrEmpty(resource) == false)
                    {
                        Database.ExecuteNonQuery(_dbConnection, resource);
                    }
                }
            }
        }
    }
}
