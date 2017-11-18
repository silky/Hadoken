#region Using References

using System;
using System.Data;
using System.Data.Common;

using Npgsql;

#endregion

namespace Hadoken.Data
{
    public static class CommandFactory
	{
        private static DbCommand NewCommand(DbConnection dbConnection, CommandType commandType)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandType = commandType;

            return dbCommand;
        }

        private static DbCommand NewCommand(DbConnection dbConnection, CommandType commandType, string commandText)
        {
            DbCommand dbCommand = NewCommand(dbConnection, commandType);

            dbCommand.CommandText = commandText;

            return dbCommand;
        }

        private static DbCommand NewCommand(DbConnection dbConnection, CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            DbCommand dbCommand = NewCommand(dbConnection, commandType, commandText);

            if ((dbParameters != null) && (dbParameters.Length > 0))
            {
                dbCommand.Parameters.AddRange(dbParameters);
            }

            return dbCommand;
        }

        public static DbCommand NewStoredProcedureCommand(DbConnection dbConnection, string commandText)
        {
            return NewCommand(dbConnection, CommandType.StoredProcedure, commandText);
        }

        public static DbCommand NewStoredProcedureCommand(DbConnection dbConnection, string commandText, DbParameter[] dbParameters)
        {
            return NewCommand(dbConnection, CommandType.StoredProcedure, commandText, dbParameters);
        }

        public static DbCommand NewTextCommand(DbConnection dbConnection)
        {
            return NewCommand(dbConnection, CommandType.Text);
        }

        public static DbCommand NewTextCommand(DbConnection dbConnection, string commandText)
        {
            DbCommand dbCommand = NewTextCommand(dbConnection);

            dbCommand.CommandText = commandText;

            return dbCommand;
        }
    }
}
