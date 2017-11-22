#region Using References

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Hadoken.Core.IO
{
    public static class Storage
    {
        public static void CreateDirectory(string DirectoryPath)
        {
            if (Directory.Exists(DirectoryPath) == false)
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

		public static string ReadFile(string FilePath)
        {
            string readFile = "";

            if (File.Exists(FilePath) == true)
            {
                using (StreamReader oStreamReader = new StreamReader(File.OpenRead(FilePath)))
                {
                    readFile = oStreamReader.ReadToEnd();
                }
            }

            return readFile;
        }

		public static List<string> ReadFile<T>(string FilePath)
		{
			List<string> readFile = null;

			if (File.Exists(FilePath) == true)
			{
				using (StreamReader oStreamReader = new StreamReader(File.OpenRead(FilePath)))
				{
					readFile = oStreamReader
						.ReadToEnd()
						.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
						.ToList();
				}
			}

			return readFile;
		}

		public static void WriteFile(string FilePath, string Contents)
        {
            if (String.IsNullOrEmpty(Contents) == false)
            {
                if (File.Exists(FilePath) == true)
                {
                    File.Delete(FilePath);
                }

                using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(FilePath)))
                {
                    streamWriter.Write(Contents);
                }
            }
        }

		public static void WriteFile(string FilePath, List<string> FileLines)
		{
			if (FileLines.Count > 0)
			{
				if (File.Exists(FilePath) == true)
				{
					File.Delete(FilePath);
				}

				using (StreamWriter streamWriter = new StreamWriter(File.OpenWrite(FilePath)))
				{
					FileLines.ForEach(m => streamWriter.WriteLine(m));
				}
			}
		}
	}
}
