using DownloaderHTTP.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderHTTP.Extensions
{
    public static class HttpDialog
    {
        public static async Task<string[]> GetRequestAndResponseStringArreyAsync(string serverUrl, string pathCommand)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverUrl + pathCommand);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Unicode);
            if (IsErrorOnTheServer(response))
                return null;
            var result = JsonSerializeHelper.Deserialize<string[]>(sr.ReadToEnd());
            sr.Close();
            return result;
        }
        public static async Task<string> GetRequestAndResponseStringAsync(string serverUrl, string pathCommand)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( serverUrl + pathCommand);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Unicode);
            if (IsErrorOnTheServer(response))
                return null;
            var result = sr.ReadToEnd();
            sr.Close();
            return result;
        }
        public static async Task<byte[]> GetRequestAndResponseByteArreyAsync(string serverUrl, string pathCommand)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverUrl + pathCommand);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Unicode);
            if (IsErrorOnTheServer(response))
                return null;
            var result = sr.ReadToEnd();
            sr.Close();
            return Convert.FromBase64String(result);
        }

        private static bool IsErrorOnTheServer(HttpWebResponse response)
        {
            return response.StatusCode != HttpStatusCode.OK;
        }
    }
}
