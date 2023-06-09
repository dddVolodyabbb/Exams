using SeekerOfForbidden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seeker_of_forbidden_cmd
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SeekerOfForbiddenClass censorship = new SeekerOfForbiddenClass();
            censorship.searchDrectoryPath = "G:\\";
            censorship.pathToTheForbiddenWordsDictionary="G:\\slovar.txt";
            censorship.searchAcrossAllDrives = false;
            censorship.reportOnly = false;
            censorship.folderPathForFilesWithForbiddenWords = "G:\\zapret";
            censorship.pathToTheReportFile = "G:\\zapret\\Reports";
            censorship.StartAutoSearchingAndFix();
            censorship.PrintAllReportsToConsole();
            Console.ReadKey();
        }
    }
}
