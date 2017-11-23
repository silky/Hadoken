#region Using References

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Hadoken.Core.IO;

#endregion

namespace Hadoken.Data
{
    public class PostgresDatabase : Database
    {
        public PostgresDatabase(string name)
            : this(name, ConnectionFactory.NewDbConnection())
        {
        }

        public PostgresDatabase(string name, DbConnection dbConnection)
            : base(name, dbConnection)
        {
        }

        public override void Create()
        {
            OutputStreams.WriteLine("Creating database...");

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"CREATE DATABASE {Name}");
            stringBuilder.AppendLine("  WITH OWNER = postgres");
            stringBuilder.AppendLine("       ENCODING = 'UTF8'");
            stringBuilder.AppendLine("       TABLESPACE = pg_default");
            stringBuilder.AppendLine(" CONNECTION LIMIT = -1;");

            ExecuteNonQuery(stringBuilder.ToString());

            OutputStreams.WriteLine("Database created.");
        }

        public override void Drop()
        {
            OutputStreams.WriteLine("Dropping database...");

            ExecuteNonQuery($"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = '{Name}';");
            ExecuteNonQuery($"DROP DATABASE IF EXISTS {Name};");

            OutputStreams.WriteLine("Database dropped.");
        }

        public override bool IsExists()
        {
            bool isExists = false;

            using (DbDataReader dbDataReader = ExecuteReader($"SELECT 1 FROM pg_database WHERE datname = '{Name}'"))
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
