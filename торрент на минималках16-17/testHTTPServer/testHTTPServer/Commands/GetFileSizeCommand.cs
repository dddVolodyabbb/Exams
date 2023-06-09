using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using testHTTPServer.Extensions;

namespace testHTTPServer.Commands
{
    public class GetFileSizeCommand : ICommand
    {
        private readonly string folderPath = "E:\\Сloud";
        private const string loadFileName = "loadFileName";
        public string Path => @$"/SizeFile/(?<{loadFileName}>.+)";
        public HttpMethod Method => HttpMethod.Get;

        public async Task HandleRequestAsync(HttpListenerContext context)
        {
            var match = Regex.Match(context.Request.Url.AbsolutePath, Path, RegexOptions.IgnoreCase);
            var fileName = match.Groups[loadFileName].Value;
            var filePath = System.IO.Path.Combine(folderPath, fileName);
            if (File.Exists(folderPath))
            {
                await context.WriteResponseAsync(404, "Файла не существует").ConfigureAwait(false);
                return;
            }
            await context.WriteResponseAsync(200,new FileInfo(filePath).Length.ToString()).ConfigureAwait(false);
        }
    }
}
