using ConsumingLibrary;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MP_MediaInfo_Repro
{
    internal static class Program
    {
        private static void Main()
        {
            string thisAssemblyLocation = Assembly.GetExecutingAssembly().Location;

            var res = CorFlagsReader.ReadAssemblyMetadata(thisAssemblyLocation);
            string arch = !res.Is32BitPref && !res.Is32BitReq ? res.ProcessorArchitecture == ProcessorArchitecture.MSIL ? "Any CPU" : "x64" : "x86";
            Console.WriteLine($"Current assembly was targetted as {arch}.");

            string baseDir = Path.GetDirectoryName(thisAssemblyLocation);
            Console.WriteLine($"lib* files in execution directory: {Directory.EnumerateFiles(baseDir, "lib*", SearchOption.TopDirectoryOnly).Count()}.");

            var log = new StringBuilder();
            bool result = new UseMediaInfo(log).TryLoading("dummy.mp4");

            Console.WriteLine($"MediaInfo was{(!result ? " NOT" : string.Empty)} loaded.");
            Console.WriteLine();
            Console.WriteLine("MediaInfoWrapper logging:");
            Console.WriteLine();
            // really messy elaborate way to add tabs to log output
            Console.WriteLine(string.Join(Environment.NewLine, log.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(l => $"\t{l}")));

            Console.WriteLine("Press anything to exit.");
            Console.ReadKey(true);
        }
    }
}
