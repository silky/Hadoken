#region Using References

using System;
using System.IO;
using System.Net;

#endregion

namespace Hadoken.Core.IO
{
    public static class Http
    {
        public const string UserAgent = "Mozilla/5.0 CMS (.NET Core 2.0) s3364859@student.rmit.edu.au";

        public static string Get(string Url)
        {
            return Get(Url, true);
        }

        public static string Get(string Url, string HeaderName, string HeaderValue)
        {
            return Get(Url, HeaderName, HeaderValue, true);
        }

        public static string Get(string Url, bool IsLogToConsole)
        {
            return Get(Url, "", "", IsLogToConsole);
        }

        public static string Get(string Url, string HeaderName, string HeaderValue, bool IsLogToConsole)
        {
            string httpGet = "";

            if (String.IsNullOrEmpty(Url) == false)
            {
                HttpWebRequest oHttpWebRequest = HttpWebRequest.CreateHttp(Url);
                oHttpWebRequest.Method = "GET";
                oHttpWebRequest.UserAgent = UserAgent;

                if ((String.IsNullOrEmpty(HeaderName) == false) && (String.IsNullOrEmpty(HeaderValue) == false))
                {
                    oHttpWebRequest.Headers.Add(HeaderName, HeaderValue);
                }

                if (IsLogToConsole == true)
                {
                    OutputStreams.Write($"Downloading from {Url}...");
                }

                using (WebResponse httpWebResponse = oHttpWebRequest.GetResponseAsync().Result)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        httpGet = streamReader.ReadToEnd().Replace("\r", Environment.NewLine);
                    }
                }

                if (IsLogToConsole == true)
                {
                    OutputStreams.WriteLine("Done", false);
                }
            }

            return httpGet;
        }
    }
}
