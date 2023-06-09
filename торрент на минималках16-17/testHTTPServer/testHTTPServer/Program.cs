using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testHTTPServer.Commands;

namespace testHTTPServer
{
    internal class Program
    {
        private const string ServerUri = "http://127.0.0.1:8888/";
        static async Task Main(string[] args)
        {
            await CreateServer().StartAsync(ServerUri).ConfigureAwait(false);
        }

        private static IServer CreateServer()
        {
            return new Server(
                new GetSummaCommand(),
                new GetAllFilesCommand(),
                new GetDownloadFileCommand(),
                new GetFileSizeCommand()
                );
        }
    }
}
