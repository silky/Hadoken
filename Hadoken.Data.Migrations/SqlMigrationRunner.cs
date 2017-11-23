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
    public class SqlMigrationRunner : MigrationRunner
    {
        public SqlMigrationRunner(DbConnection dbConnection)
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
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"IF NOT EXISTS(SELECT * FROM sys.schemas WHERE Name = '{MigrationSchemaName}')");
            stringBuilder.AppendLine("BEGIN");
            stringBuilder.AppendLine($"  EXEC('CREATE SCHEMA [{MigrationSchemaName}] AUTHORIZATION [dbo]')");
            stringBuilder.AppendLine("END");

            ExecuteNonQuery(stringBuilder.ToString());
        }

        protected override void CreateMigrationTable()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SET ANSI_NULLS ON");

            stringBuilder.AppendLine("SET QUOTED_IDENTIFIER ON");

            stringBuilder.AppendLine($"IF NOT EXISTS(SELECT * FROM sys.tables WHERE Name = '{MigrationTableName}' AND schema_id IN (SELECT schema_id FROM sys.schemas WHERE Name = '{MigrationSchemaName}'))");
            stringBuilder.AppendLine("BEGIN");

            stringBuilder.AppendLine($"CREATE TABLE [{MigrationSchemaName}].[{MigrationTableName}]");
            stringBuilder.AppendLine("(");
            stringBuilder.AppendLine("    [ID] [int] IDENTITY(1, 1) NOT NULL,");
            stringBuilder.AppendLine("    [Value] [int] NOT NULL,");
            stringBuilder.AppendLine("    [DateTime] [datetime] NOT NULL,");
            stringBuilder.AppendLine($"CONSTRAINT [PK_{MigrationTableName}] PRIMARY KEY CLUSTERED");
            stringBuilder.AppendLine("(");
            stringBuilder.AppendLine("   [ID] ASC");
            stringBuilder.AppendLine(")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]");
            stringBuilder.AppendLine(") ON [PRIMARY]");

            stringBuilder.AppendLine($"ALTER TABLE [{MigrationSchemaName}].[{MigrationTableName}] ADD CONSTRAINT [DF_{MigrationTableName}_DateTime]  DEFAULT(getdate()) FOR[DateTime]");

            stringBuilder.AppendLine("END");

            ExecuteNonQuery(stringBuilder.ToString());
        }

        protected override int GetMigrationState()
        {
            int getMigrationState = 0;

            //  using (DbCommand dbCommand = CommandFactory.NewTextCommand(_dbConnection, $"SELECT COALESCE(MAX(Value), 0) AS Value FROM {MigrationSchemaName}.{MigrationTableName};"))
            //  {
            //      using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
            //      {
            //          while (dbDataReader.Read() == true)
            //          {
            //              getMigrationState = Convert.ToInt32(dbDataReader["Value"]);
            //          }
            //      }
            //  }

            return getMigrationState;
        }
    }
}
