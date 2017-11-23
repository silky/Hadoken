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

        public static string Get(string url)
        {
            return Get(url, true);
        }

        public static string Get(string url, string headerName, string headerValue)
        {
            return Get(url, headerName, headerValue, true);
        }

        public static string Get(string url, bool isLogToConsole)
        {
            return Get(url, "", "", isLogToConsole);
        }

        public static string Get(string url, string headerName, string headerValue, bool isLogToConsole)
        {
            string httpGet = "";

            if (String.IsNullOrEmpty(url) == false)
            {
                HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = UserAgent;

                if ((String.IsNullOrEmpty(headerName) == false) && (String.IsNullOrEmpty(headerValue) == false))
                {
                    httpWebRequest.Headers.Add(headerName, headerValue);
                }

                if (isLogToConsole == true)
                {
                    OutputStreams.WriteLine($"Downloading from {url}...");
                }

                using (WebResponse httpWebResponse = httpWebRequest.GetResponseAsync().Result)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        httpGet = streamReader.ReadToEnd().Replace("\r", Environment.NewLine);
                    }
                }

                if (isLogToConsole == true)
                {
                    OutputStreams.WriteLine("Finished downloading");
                }
            }

            return httpGet;
        }
    }
}
