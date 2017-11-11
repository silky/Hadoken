#region Using References

using System;
using System.Diagnostics;

#endregion

namespace Hadoken.Core.Logging
{
	public static class OutputStreams
	{
		public static void WriteLine()
		{
			Console.WriteLine();
			Debug.WriteLine("");
		}

		public static void WriteLine(string value)
		{
			WriteLine(value, true);
		}

		public static void WriteLine(string value, bool isIncludeTimestamp)
		{
			string message = ((isIncludeTimestamp == true) ? $"{DateTime.Now.ToString("yyyy-MMM-dd @ HH:mm:ss")} {value}" : value);

			Console.WriteLine(message);
			Debug.WriteLine(message);
		}
	}
}
