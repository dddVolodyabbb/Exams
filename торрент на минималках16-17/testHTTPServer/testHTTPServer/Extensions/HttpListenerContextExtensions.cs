using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace testHTTPServer.Extensions
{
    public static class HttpListenerContextExtensions
    {
        public static async Task<string> GetRequestBodyAsync(this HttpListenerContext context, Encoding encoding = null)
        {
            using var streamReader = new StreamReader(context.Request.InputStream, encoding ?? Encoding.Unicode);
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }

        public static async Task WriteResponseAsync(this HttpListenerContext context, int statusCode, string value = null)
        {
            context.Response.StatusCode = statusCode;
            using var streamWriter = new StreamWriter(context.Response.OutputStream, Encoding.Unicode);
            await streamWriter.WriteAsync(value).ConfigureAwait(false);
            WebClient client = new WebClient();
           
        }
    }
}
