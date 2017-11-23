#region Using References

using System;
using System.Data.Common;
using System.Data.SqlClient;

using Hadoken.Core;

#endregion

namespace Hadoken.Data
{
	public static class ConnectionFactory
	{
		static ConnectionFactory()
		{
			_connectionString = new SqlConnectionStringBuilder(ApplicationConfiguration.HadokenConnectionString).ConnectionString;
		}

		private static string _connectionString;

		public static DbConnection NewDbConnection()
		{
            return NewDbConnection(_connectionString);
		}

        public static DbConnection NewDbConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }
    }
}
