#region Using References

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Hadoken.Core.IO;
using System.Collections.Generic;

#endregion

namespace Hadoken.Data
{
    public class SqlDatabase : Database
    {
        public SqlDatabase(string name)
            : this(name, ConnectionFactory.NewDbConnection())
        {
        }

        public SqlDatabase(string name, DbConnection dbConnection)
            : base (name, dbConnection)
        {
        }

        public override void Create()
        {
            OutputStreams.WriteLine("Creating database...");

            StringBuilder stringBuilder = new StringBuilder();

            ExecuteNonQuery($"CREATE DATABASE [{Name}]");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET ANSI_NULL_DEFAULT OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET ANSI_NULLS OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET ANSI_PADDING OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET ANSI_WARNINGS OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET ARITHABORT OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET AUTO_CLOSE OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET AUTO_SHRINK OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET AUTO_UPDATE_STATISTICS ON");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET CURSOR_CLOSE_ON_COMMIT OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET CURSOR_DEFAULT  GLOBAL");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET CONCAT_NULL_YIELDS_NULL OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET NUMERIC_ROUNDABORT OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET QUOTED_IDENTIFIER OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET RECURSIVE_TRIGGERS OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET DISABLE_BROKER");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET DATE_CORRELATION_OPTIMIZATION OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET TRUSTWORTHY OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET ALLOW_SNAPSHOT_ISOLATION OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET PARAMETERIZATION SIMPLE");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET READ_COMMITTED_SNAPSHOT OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET HONOR_BROKER_PRIORITY OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET RECOVERY FULL");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET MULTI_USER");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET PAGE_VERIFY CHECKSUM");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET DB_CHAINING OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET TARGET_RECOVERY_TIME = 60 SECONDS");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET DELAYED_DURABILITY = DISABLED");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET QUERY_STORE = OFF");

            ExecuteNonQuery($"ALTER DATABASE [{Name}] SET READ_WRITE");

            OutputStreams.WriteLine("Database created.");
        }

        public override void Drop()
        {
            OutputStreams.WriteLine("Dropping database...");

            List<int> spidList = new List<int>();

            using (DbDataReader dbDataReader = ExecuteReader("EXEC sp_who2"))
            {
                while (dbDataReader.Read() == true)
                {
                    string name = dbDataReader["DBName"].ToString();
                    int spid = Convert.ToInt32(dbDataReader["SPID"]);

                    if ((name.ToUpper() == Name.ToUpper()) && (spidList.Contains(spid) == false))
                    {
                        spidList.Add(spid);
                    }
                }
            }

            foreach (int spid in spidList)
            {
                ExecuteNonQuery($"KILL {spid}");
            }

            ExecuteNonQuery($"DROP DATABASE {Name};");

            OutputStreams.WriteLine("Database dropped.");
        }

        public override bool IsExists()
        {
            bool isExists = false;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT");
            stringBuilder.AppendLine("  CASE");
            stringBuilder.AppendLine($"        WHEN EXISTS(SELECT * FROM sys.databases WHERE Name = '{Name}') THEN 1");
            stringBuilder.AppendLine("  ELSE 0");
            stringBuilder.AppendLine("END");

            using (DbDataReader dbDataReader = ExecuteReader(stringBuilder.ToString()))
            {
                while (dbDataReader.Read() == true)
                {
                    isExists = Convert.ToBoolean(dbDataReader[0]);
                }
            }

            return isExists;
        }
    }
}
