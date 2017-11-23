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

        internal const string MigrationSchemaName = "Migration";
        internal const string MigrationTableName = "State";

        protected virtual int BumpMigrationState()
        {
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

        protected virtual void CreateMigrationSchema()
        {
        }

        protected virtual void CreateMigrationTable()
        {
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
                IEnumerable<Attribute> customAttributes = migration.GetType().GetCustomAttributes();
                MigrationAttribute migrationAttribute = customAttributes.OfType<MigrationAttribute>().FirstOrDefault();
                DataPlatformAttribute dataPlatformAttribute = customAttributes.OfType<DataPlatformAttribute>().FirstOrDefault();
                DataPlatformType dataPlatformType = ((dataPlatformAttribute == null) ? DataPlatformType.Unknown : dataPlatformAttribute.DataPlatformType);

                OutputStreams.WriteLine($"Found migration {migrationAttribute.Value}");

                if (dataPlatformType != DataPlatformType.Unknown)
                {
                    if ((migrationAttribute.Value > migrationState) && (migrationAttribute.IsIgnore == false))
                    {
                        try
                        {
                            OutputStreams.WriteLine($"Applying migration {migrationAttribute.Value}...");

                            migration.Apply(dataPlatformType);

                            migrationState = BumpMigrationState();
                        }
                        catch
                        {
                            migration.Rollback(dataPlatformType);

                            throw;
                        }
                    }
                    else
                    {
                        OutputStreams.WriteLine($"Skipping migration {migrationAttribute.Value}...");
                    }
                }
            }
        }

        internal void ExecuteNonQuery(string commandText)
        {
            Database.ExecuteNonQuery(_dbConnection, commandText);
        }

        internal DbDataReader ExecuteReader(string commandText)
        {
            return Database.ExecuteReader(_dbConnection, commandText);
        }

        protected virtual int GetMigrationState()
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
