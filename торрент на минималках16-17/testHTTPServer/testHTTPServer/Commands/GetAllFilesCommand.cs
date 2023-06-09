using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testHTTPServer.Extensions;
using testHTTPServer.Helpers;

namespace testHTTPServer.Commands
{
    internal class GetAllFilesCommand : ICommand
    {
        private string folderAvailableFiles = "E:\\Сloud";
        public string Path => @"/AllFiles";
        public HttpMethod Method => HttpMethod.Get;

        public async Task HandleRequestAsync(HttpListenerContext context)
        {
            //List<string> availableFiles = new List<string>();
            var response = Directory.GetFiles(folderAvailableFiles);
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = System.IO.Path.GetFileName(response[i]);
            }
            await context.WriteResponseAsync(200, JsonSerializeHelper.Serialize(response)).ConfigureAwait(false);
        }
    }
}
