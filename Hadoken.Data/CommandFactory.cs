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
		public static DbCommand NewCommand(DbConnection dbConnection)
		{
            return dbConnection.CreateCommand();
		}

        public static DbCommand NewCommand(DbConnection dbConnection, CommandType commandType)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandType = commandType;

            return dbCommand;
        }

        public static DbCommand NewStoredProcedureCommand(DbConnection dbConnection)
        {
            return NewCommand(dbConnection, CommandType.StoredProcedure);
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
