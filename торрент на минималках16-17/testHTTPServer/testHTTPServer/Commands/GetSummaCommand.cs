using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using testHTTPServer.Extensions;
using testHTTPServer.Helpers;

namespace testHTTPServer.Commands
{
    public class GetSummaCommand:ICommand
    {
        private const string numberA = "a";
        private const string numberB = "b";
        public string Path => @$"/summ/(?<{numberA}>\d+)&(?<{numberB}>\d+)";
        public HttpMethod Method => HttpMethod.Get;
        public async Task HandleRequestAsync(HttpListenerContext context)
        {
            var match = Regex.Match(context.Request.Url.AbsolutePath, Path, RegexOptions.IgnoreCase);
            var numA = int.Parse(match.Groups[numberA].Value);
            var numB = int.Parse(match.Groups[numberB].Value);
            int response =  numA + numB ;
            await context.WriteResponseAsync(200, JsonSerializeHelper.Serialize(response)).ConfigureAwait(false);
        }
    }
}
