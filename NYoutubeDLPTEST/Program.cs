using System;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using NYoutubeDL;

namespace NYoutubeDLP_Reproducible
{
    class NYoutubeDLP_Reproducible
    {
        public static async Task Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            YoutubeDLP youtubeDl = new YoutubeDLP();
            youtubeDl.Options.GeneralOptions.Update = true;
            youtubeDl.Options.VerbositySimulationOptions.Verbose = true;
            youtubeDl.Options.VerbositySimulationOptions.Print = "";
            youtubeDl.Options.FilesystemOptions.Paths = "C:\\";
            Regex outputTest = new Regex("Destination:");

            youtubeDl.StandardOutputEvent += (sender, output) => {
                System.Diagnostics.Debug.WriteLine("STANDARDOUTPUT: " + output);
                if (outputTest.IsMatch(output))
                {
                    // Put breakpoints here and check the value of the output
                    // Will lack unicode characters, demonstrating that the output from the StandardOutput event handler has dropped the utf-8 encoding.
                    System.Diagnostics.Debug.WriteLine("STANDARDOUTPUT: " + output);
                }
            };

            // This echo will print out the correct characters
            youtubeDl.Options.PostProcessingOptions.Command = "echo";
            // This starts the download, thus starting the youtube-dlp process
            await youtubeDl.DownloadAsync("https://www.youtube.com/watch?v=oGAqZakJoMg");
        }
    }
}
