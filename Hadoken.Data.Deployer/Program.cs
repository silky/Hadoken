#region Using References

using System;
using System.Data.Common;
using System.Text;

using Npgsql;

using Hadoken.Core;
using Hadoken.Core.Logging;
using Hadoken.Data.Migrations;

#endregion

namespace Hadoken.Data.Deployer
{
    public class Program
    {
        private const int ErrorInvalidFunction = 1;
        private const int ErrorSuccess = 0;
        private const string MigrationNamespace = "Hadoken.Data.Migrations";

        private static void CreateDatabase(DbConnection dbConnection, string databaseName)
        {
            OutputStreams.WriteLine("Creating database...");

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"CREATE DATABASE {databaseName}");
            stringBuilder.AppendLine("  WITH OWNER = postgres");
            stringBuilder.AppendLine("       ENCODING = 'UTF8'");
            stringBuilder.AppendLine("       TABLESPACE = pg_default");
            stringBuilder.AppendLine("       LC_COLLATE = 'English_Australia.1252'");
            stringBuilder.AppendLine("       LC_CTYPE = 'English_Australia.1252'");
            stringBuilder.AppendLine(" CONNECTION LIMIT = -1;");

            ExecuteNonQuery(dbConnection, stringBuilder.ToString());

            OutputStreams.WriteLine("Database created.");
        }

        private static void DropDatabase(DbConnection dbConnection, string databaseName)
        {
            OutputStreams.WriteLine("Dropping database...");

            ExecuteNonQuery(dbConnection, $"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = '{databaseName}';");
            ExecuteNonQuery(dbConnection, $"DROP DATABASE IF EXISTS {databaseName};");

            OutputStreams.WriteLine("Database dropped.");
        }

        private static void ExecuteNonQuery(DbConnection dbConnection, string sql)
        {
            using (DbCommand command = CommandFactory.NewTextCommand(dbConnection, sql))
            {
                command.ExecuteNonQuery();
            }
        }

        public static void Main(string[] arguments)
        {
            OutputStreams.WriteLine();
            OutputStreams.WriteLine("Hadoken Database Migrator");
            OutputStreams.WriteLine();

            try
            {
                CommandLineParser commandLineParser = new CommandLineParser(arguments);

                NpgsqlConnectionStringBuilder sqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(ApplicationConfiguration.HadokenConnectionString);

                string targetDatabase = sqlConnectionStringBuilder.Database.ToLower();

                //	Switch over to master db to do admin type stuff
                sqlConnectionStringBuilder.Database = "postgres";

                using (DbConnection dbConnection = ConnectionFactory.NewDbConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    if (commandLineParser.IsDrop == true)
                    {
                        DropDatabase(dbConnection, targetDatabase);
                    }

                    CreateDatabase(dbConnection, targetDatabase);
                }

                //	Switch back to target db to run migrations
                sqlConnectionStringBuilder.Database = targetDatabase;

                using (DbConnection dbConnection = ConnectionFactory.NewDbConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    RunMigration(dbConnection);
                }

                Environment.ExitCode = ErrorSuccess;
            }
            catch (Exception exception)
            {
                while (exception != null)
                {
                    OutputStreams.WriteLine(exception.Message);
                    OutputStreams.WriteLine(exception.StackTrace);
                    OutputStreams.WriteLine();

                    exception = exception.InnerException;
                }

                Environment.ExitCode = ErrorInvalidFunction;
            }

            OutputStreams.WriteLine();
            OutputStreams.WriteLine("Process complete.");
            OutputStreams.WriteLine();
        }

        private static void RunMigration(DbConnection dbConnection)
        {
            if ((dbConnection != null) && (String.IsNullOrEmpty(dbConnection.ConnectionString) == false))
            {
                MigrationRunner migrationRunner = new MigrationRunner(dbConnection);
            }
        }
    }
}
