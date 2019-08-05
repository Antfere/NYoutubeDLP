# NYoutubeDL

[![pipeline status](https://gitlab.com/BrianAllred/NYoutubeDL/badges/master/pipeline.svg)](https://gitlab.com/BrianAllred/NYoutubeDL/commits/master)

A simple youtube-dl library for C#.

See the [main page](https://rg3.github.io/youtube-dl/) for youtube-dl for more information.

## Usage

### Getting the package

#### Visual Studio

* Search for `NYoutubeDL` in your project's NuGet Manager and click install.
  
Or

* In the NuGet package manager console, run

        PM> Install-Package NYoutubeDL

#### DotNet Core

* In a terminal in your project's folder, run

        dotnet add package NYoutubeDL

#### Alternatively

* Manually [download](https://www.nuget.org/packages/NYoutubeDL/) nupkg from NuGet Gallery.

### Using the code

See the [documentation](https://github.com/rg3/youtube-dl/blob/master/README.md#readme) for youtube-dl first to understand what it does and how it does it.

1. Create a new YoutubeDL client:

        var youtubeDl = new YoutubeDL();

2. Options are grouped according to the youtube-dl documentation:

        youtubeDl.Options.FilesystemOptions.Output = "/path/to/downloads/video.mp4";
        youtubeDl.Options.PostProcessingOptions.ExtractAudio = true;
        youtubeDl.VideoUrl = "http://www.somevideosite.com/videoUrl";

        // Or update the binary
        youtubeDl.Options.GeneralOptions.Update = true;

        // Optional, required if binary is not in $PATH
        youtubeDl.YoutubeDlPath = "/path/to/youtube-dl";

3. Options can also be saved and loaded. Only changed options will be saved.

        File.WriteAllText("options.config", youtubeDl.Options.Serialize());
        youtubeDl.Options = Options.Deserialize(File.ReadAllText("options.config"));

4. Subscribe to the console output (optional, but recommended):

        youtubeDl.StandardOutputEvent += (sender, output) => Console.WriteLine(output);
        youtubeDl.StandardErrorEvent += (sender, errorOutput) => Console.WriteLine(errorOutput);

5. Subscribe to download information updates. Hard subscription is optional, the DownloadInfo class implements INotifyPropertyChanged.

        youtubeDl.Info.PropertyChanged += delegate { <your code here> };

6. Start the download:

        // Prepare the download (in case you need to validate the command before starting the download)
        string commandToRun = await youtubeDl.PrepareDownloadAsync();
        // Alternatively
        string commandToRun = youtubeDl.PrepareDownload();

         // Just let it run
        youtubeDl.DownloadAsync();

        // Wait for it
        youtubeDl.Download();

        // Or provide video url
        youtubeDl.Download("http://videosite.com/videoUrl");

### Workaround for IIS

There is a weird permissions issue that ocurrs when invoking youtube-dl from an ASP.NET/IIS process. In this case, perform the following steps

1. Install Python on the server.

2. Download and place the Python version of youtube-dl (not the executable binary) somewhere on the server. This can be found [here](https://yt-dl.org/downloads/latest/youtube-dl).

3. When creating the YoutubeDL client object, set the `PythonPath` property to the path of the Python executable binary and the `YoutubeDlPath` to the path of the python version of youtube-dl.

## Reporting issues

While both youtube-dl itself and this library support many different services, my personal use centers around Youtube. If you find any bugs using this library with other services, feel free to raise an issue. **Please provide a specific link/URL, if possible.**

## Contributing

Pull requests for bug fixes are more than welcome! If you find and fix an issue, make a pull request with the bug and fix clearly described.

Pull requests for features will be considered, although I'm not sure what else this library needs to do. If you have an idea for a new feature, **please raise an issue first** in order to start a discussion. This saves both you and me time. I don't want anyone to code an elaborate feature and write up an immaculate pull request if it doesn't belong in this library.
