using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using testHTTPServer.Extensions;
using testHTTPServer.Helpers;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.IO.Pipes;

namespace testHTTPServer.Commands
{
    internal class GetDownloadFileCommand : ICommand
    {
        private readonly string folderPath = "E:\\Сloud";
        private const string FileName = "FileName";
        private const string LoadByte = "LoadByte";
        private const string ChunkMultiplier = "ChunkMultiplier";
        public string Path => @$"/DownloadFile/(?<{FileName}>.+)/(?<{LoadByte}>\d+)/(?<{ChunkMultiplier}>\d+)";
        public HttpMethod Method => HttpMethod.Get;

        public async Task HandleRequestAsync(HttpListenerContext context)
        {
            var match = Regex.Match(context.Request.Url.AbsolutePath, Path, RegexOptions.IgnoreCase);
            var fileName = match.Groups[FileName].Value;
            var loadByte = long.Parse(match.Groups[LoadByte].Value);
            var chunkMultiplier = int.Parse(match.Groups[ChunkMultiplier].Value);

            var filePath = System.IO.Path.Combine(folderPath, fileName);
            if (IsError(filePath, loadByte, chunkMultiplier, context).Result)
                return;

            var result = ParseFile(filePath, loadByte, chunkMultiplier).Result;
            if (result == null)
            {
                await context.WriteResponseAsync(500, "У нас что-то сломалось").ConfigureAwait(false);
                return;
            }
            await context.WriteResponseAsync(200, Convert.ToBase64String(result)).ConfigureAwait(false);
        }

        private async Task<byte[]> ParseFile(string filePuth, long loadByte, int chunkMultiplier)
        {
            long sizeChank = 1024 * 1024 * chunkMultiplier;
            using (FileStream inputFile = new FileStream(filePuth, FileMode.Open, FileAccess.Read))
            {
                var leftToLoad = (new FileInfo(filePuth).Length) - loadByte;
                inputFile.Seek(loadByte, SeekOrigin.Begin);
                try
                {
                    var buffer = leftToLoad < sizeChank ? new byte[leftToLoad] : new byte[sizeChank];
                    await inputFile.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    return buffer;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
        private async Task<bool> IsError(string filePath, long loadByte, int chunkMultiplier, HttpListenerContext context)
        {
            bool error = false;
            if (File.Exists(folderPath))
            {
                await context.WriteResponseAsync(404, "Файла не существует").ConfigureAwait(false);
                error = true;
            }

            if (loadByte > (new FileInfo(filePath).Length) || loadByte < 0)
            {
                await context.WriteResponseAsync(412, "Не правельный размер файла").ConfigureAwait(false);
                error = true;
            }

            if (chunkMultiplier > 5 || loadByte < 0)
            {
                await context.WriteResponseAsync(412, "Не поддерживаемый размер буфера").ConfigureAwait(false);
                error = true;
            }

            return error;
        }
    }
}
