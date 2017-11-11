#region Using References

using System;
using System.Data.Common;

using Npgsql;

using Hadoken.Core;

#endregion

namespace Hadoken.Data
{
	public static class ConnectionFactory
	{
		static ConnectionFactory()
		{
			_connectionString = new NpgsqlConnectionStringBuilder(ApplicationConfiguration.HadokenConnectionString).ConnectionString;
		}

		private static string _connectionString;

		public static DbConnection NewDbConnection()
		{
            return NewDbConnection(_connectionString);
		}

        public static DbConnection NewDbConnection(string connectionString)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            connection.Open();

            return connection;
        }
    }
}
