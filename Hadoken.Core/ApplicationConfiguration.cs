#region Using References

using System;
using System.Configuration;

#endregion

namespace Hadoken.Core
{
	public sealed class ApplicationConfiguration
	{
        private static string _hadokenConnectionString;

        public const string HadokenConnectionStringKey = "HadokenConnectionString";

		public static string HadokenConnectionString
        {
			get
			{
                if (String.IsNullOrEmpty(_hadokenConnectionString) == true)
                {
                    _hadokenConnectionString = GetConnectionStringValue(HadokenConnectionStringKey);
                }

				return _hadokenConnectionString;
			}
            set
            {
                _hadokenConnectionString = value;
            }
		}

		private static string GetAppSettingsValue(string key)
		{
            return ConfigurationManager.AppSettings[key];
        }

		private static string GetConnectionStringValue(string key)
		{
			string getConnectionStringValue = "";

			if (ConfigurationManager.ConnectionStrings[key] != null)
			{
				getConnectionStringValue = ConfigurationManager.ConnectionStrings[key].ConnectionString;
			}

			return getConnectionStringValue;
		}
	}
}
