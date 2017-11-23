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
    public class PostgresMigrationRunner : MigrationRunner
    {
        public PostgresMigrationRunner(DbConnection dbConnection)
            : base(dbConnection)
        {
        }

        protected override int BumpMigrationState()
        {
            ExecuteNonQuery($"INSERT INTO {MigrationSchemaName}.{MigrationTableName} (Value) SELECT (COALESCE(MAX(Value), 0) + 1) FROM {MigrationSchemaName}.{MigrationTableName};");

            return base.BumpMigrationState();
        }

        protected override void CreateMigrationSchema()
        {
            ExecuteNonQuery($"CREATE SCHEMA IF NOT EXISTS {MigrationSchemaName} AUTHORIZATION postgres;");
        }

        protected override void CreateMigrationTable()
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

            ExecuteNonQuery(stringBuilder.ToString());
        }

        protected override int GetMigrationState()
        {
            int getMigrationState = 0;

            using (DbDataReader dbDataReader = ExecuteReader($"SELECT COALESCE(MAX(Value), 0) AS Value FROM {MigrationSchemaName}.{MigrationTableName};"))
            {
                while (dbDataReader.Read() == true)
                {
                    getMigrationState = Convert.ToInt32(dbDataReader["Value"]);
                }
            }

            return getMigrationState;
        }
    }
}
