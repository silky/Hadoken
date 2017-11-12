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
        private const string ApplicationNamespace = "Hadoken.Data.Deployer";
        private const int ErrorInvalidFunction = 1;
        private const int ErrorSuccess = 0;
        private const string MigrationNamespace = "Hadoken.Data.Migrations";

        public static void Main(string[] arguments)
        {
            OutputStreams.WriteLine();
            OutputStreams.WriteLine("Hadoken Database Migrator");
            OutputStreams.WriteLine();

            try
            {
                CommandLineParser commandLineParser = new CommandLineParser(((arguments.Length == 0) ? ApplicationNamespace : arguments[0]), arguments);

                NpgsqlConnectionStringBuilder sqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(ApplicationConfiguration.HadokenConnectionString);

                string targetDatabase = sqlConnectionStringBuilder.Database.ToLower();

                //	Switch over to master db to do admin type stuff
                sqlConnectionStringBuilder.Database = "postgres";

                using (DbConnection dbConnection = ConnectionFactory.NewDbConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    using (Database database = new Database(targetDatabase, dbConnection))
                    {
                        bool isExists = database.IsExists();

                        if ((isExists == true) && (commandLineParser.IsDrop == true))
                        {
                            database.Drop();

                            isExists = false;
                        }

                        if (isExists == false)
                        {
                            database.Create();
                        }
                    }
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
                using (MigrationRunner migrationRunner = new MigrationRunner(dbConnection))
                {
                    migrationRunner.ExecuteMigrations();
                }
            }
        }
    }
}
