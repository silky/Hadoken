#region Using References

using Hadoken.Core.Logging;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

#endregion

namespace Hadoken.Data
{
    public class Database : IDisposable
    {
        public Database(string name)
            : this(name, ConnectionFactory.NewDbConnection())
        {
        }

        public Database(string name, DbConnection dbConnection)
        {
            _name = name;
            _dbConnection = dbConnection;
        }

        private readonly DbConnection _dbConnection;
        private readonly string _name;

        public void Create()
        {
            OutputStreams.WriteLine("Creating database...");

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"CREATE DATABASE {_name}");
            stringBuilder.AppendLine("  WITH OWNER = postgres");
            stringBuilder.AppendLine("       ENCODING = 'UTF8'");
            stringBuilder.AppendLine("       TABLESPACE = pg_default");
            stringBuilder.AppendLine("       LC_COLLATE = 'English_Australia.1252'");
            stringBuilder.AppendLine("       LC_CTYPE = 'English_Australia.1252'");
            stringBuilder.AppendLine(" CONNECTION LIMIT = -1;");

            ExecuteNonQuery(_dbConnection, stringBuilder.ToString());

            OutputStreams.WriteLine("Database created.");
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

        public void Drop()
        {
            OutputStreams.WriteLine("Dropping database...");

            ExecuteNonQuery(_dbConnection, $"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = '{_name}';");
            ExecuteNonQuery(_dbConnection, $"DROP DATABASE IF EXISTS {_name};");

            OutputStreams.WriteLine("Database dropped.");
        }

        public void ExecuteNonQuery(string commandText)
        {
            ExecuteNonQuery(_dbConnection, commandText);
        }

        public static void ExecuteNonQuery(DbConnection dbConnection, string commandText)
        {
            using (DbCommand command = CommandFactory.NewTextCommand(dbConnection, commandText))
            {
                command.ExecuteNonQuery();
            }
        }

        public DbDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(_dbConnection, commandText);
        }

        public static DbDataReader ExecuteReader(DbConnection dbConnection, string commandText)
        {
            using (DbCommand command = CommandFactory.NewTextCommand(dbConnection, commandText))
            {
                return command.ExecuteReader();
            }
        }

        public bool IsExists()
        {
            bool isExists = false;

            using (DbDataReader dbDataReader = ExecuteReader(_dbConnection, $"SELECT 1 FROM pg_database WHERE datname = '{_name}'"))
            {
                while (dbDataReader.Read() == true)
                {
                    isExists = true;
                    break;
                }
            }

            return isExists;
        }
    }
}
