﻿// Copyright 2021 Brian Allred
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

namespace NYoutubeDL.Tests
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Helpers;
    using Models;
    using Options;
    using Xunit;

    #endregion

    public class Tests
    {
        [Fact]
        public void TestBoolOption()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string extractAudioOptionString = " -x ";

            ydlClient.Options.PostProcessingOptions.ExtractAudio = true;

            Assert.Contains(extractAudioOptionString, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestDateTimeOption()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string dateDateTimeOption = " --date 20170201 ";

            ydlClient.Options.VideoSelectionOptions.Date = new DateTime(2017, 02, 01);

            Assert.Contains(dateDateTimeOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestEnumOption()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string audioFormatEnumOption = " --audio-format mp3 ";

            ydlClient.Options.PostProcessingOptions.AudioFormat = Enums.AudioFormat.mp3;

            Assert.Contains(audioFormatEnumOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestFileSizeRateOption1()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string bufferSizeFileSizeRateOption = " --buffer-size 5.5M ";

            ydlClient.Options.DownloadOptions.BufferSize = new FileSizeRate(5.5, Enums.ByteUnit.M);

            Assert.Contains(bufferSizeFileSizeRateOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestFileSizeRateOption2()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string bufferSizeFileSizeRateOption = " --buffer-size 5.5M ";

            ydlClient.Options.DownloadOptions.BufferSize = new FileSizeRate("5.5M");

            Assert.Contains(bufferSizeFileSizeRateOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestIntOption()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string socketTimeoutIntOption = " --socket-timeout 5 ";

            ydlClient.Options.NetworkOptions.SocketTimeout = 5;

            Assert.Contains(socketTimeoutIntOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestIntOptionNegativeIsInfinite()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string retriesIntOption = " -R infinite ";

            ydlClient.Options.DownloadOptions.Retries = -1;

            Assert.Contains(retriesIntOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestIsMultiDownload()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();

            ydlClient.VideoUrl = @"https://www.youtube.com/watch?v=dQw4w9WgXcQ https://www.youtube.com/playlist?list=PLrEnWoR732-BHrPp_Pm8_VleD68f9s14-";

            var info = ydlClient.GetDownloadInfo(@"https://www.youtube.com/watch?v=dQw4w9WgXcQ https://www.youtube.com/playlist?list=PLrEnWoR732-BHrPp_Pm8_VleD68f9s14-");

            Assert.NotNull(info as MultiDownloadInfo);
        }

        [Fact]
        public void TestIsPlaylistDownload()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();

            var info = ydlClient.GetDownloadInfo(@"https://www.youtube.com/playlist?list=PLrEnWoR732-BHrPp_Pm8_VleD68f9s14-");

            Assert.NotNull(info as PlaylistDownloadInfo);
        }

        [Fact]
        public void TestIsVideoDownload()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();

            var info = ydlClient.GetDownloadInfo(@"https://www.youtube.com/watch?v=dQw4w9WgXcQ");

            Assert.NotNull(info as VideoDownloadInfo);
        }

        [Fact]
        public void TestOptionDeserializer()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string optionsString =
                "{\"DownloadOptions\": {\"fragmentRetries\": -1,\"retries\": -1},\"PostProcessingOptions\": {\"audioFormat\": 0,\"audioQuality\": \"0\"},\"VideoFormatOptions\": {\"format\": 7}}";

            ydlClient.Options = Options.Deserialize(optionsString);

            Assert.Equal(-1, ydlClient.Options.DownloadOptions.FragmentRetries);
            Assert.Equal(-1, ydlClient.Options.DownloadOptions.Retries);
            Assert.Equal(Enums.VideoFormat.best, ydlClient.Options.VideoFormatOptions.Format);
            Assert.Equal(Enums.AudioFormat.best, ydlClient.Options.PostProcessingOptions.AudioFormat);
            Assert.Equal("0", ydlClient.Options.PostProcessingOptions.AudioQuality);
        }

        [Fact]
        public void TestOptionSerializer()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string optionsString =
                "{\"DownloadOptions\": {\"fragmentRetries\": -1,\"retries\": -1},\"PostProcessingOptions\": {\"audioFormat\": 0,\"audioQuality\": \"0\"},\"VideoFormatOptions\": {\"format\": 7}}";

            ydlClient.Options.DownloadOptions.FragmentRetries = -1;
            ydlClient.Options.DownloadOptions.Retries = -1;
            ydlClient.Options.VideoFormatOptions.Format = Enums.VideoFormat.best;
            ydlClient.Options.PostProcessingOptions.AudioFormat = Enums.AudioFormat.best;
            ydlClient.Options.PostProcessingOptions.AudioQuality = "0";

            string options = ydlClient.Options.Serialize();

            Assert.Equal(Regex.Replace(options, @"\s+", ""), Regex.Replace(optionsString, @"\s+", ""));
        }

        [Fact]
        public void TestStringOption()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string usernameStringOption = " -u testUser ";

            ydlClient.Options.AuthenticationOptions.Username = "testUser";

            Assert.Contains(usernameStringOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestStringOptionWithWhiteSpace()
        {
            YoutubeDLP ydlClient = new YoutubeDLP();
            const string ffmpegLocationOption = " --ffmpeg-location \"test location\" ";

            ydlClient.Options.PostProcessingOptions.FfmpegLocation = "test location";

            Assert.Contains(ffmpegLocationOption, ydlClient.PrepareDownload());
        }

        [Fact]
        public void TestVideoProgress()
        {
            YoutubeDLP youtubeDl = new YoutubeDLP();
            youtubeDl.VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

            youtubeDl.Download();

            Assert.NotNull(youtubeDl.Info);
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ")] // Standard YT video 
        [InlineData("https://www.youtube.com/watch?v=jfKfPfyJRdk")] // YT livestream 
        [InlineData("https://www.twitch.tv/monstercat")] // Twitch livestream 
        public void TestCancelAsyncDownload(string url)
        {
            const string outDir = "./out/";
            TimeSpan timeout = TimeSpan.FromSeconds(30);

            // Clean up after previous run if it failed
            List<Process> oldProcesses = Process.GetProcessesByName("yt-dlp").ToList();
            oldProcesses.AddRange(Process.GetProcessesByName("ffmpeg"));
            if (oldProcesses.Any())
                foreach (Process process in oldProcesses)
                    process.Kill();

            if (Directory.Exists(outDir))
                Directory.Delete(outDir, true);

            // Setup
            YoutubeDLP youtubeDl = new YoutubeDLP();
            youtubeDl.VideoUrl = url;
            youtubeDl.Options.FilesystemOptions.Output = Path.Join(outDir, "video");
            Directory.CreateDirectory(outDir);

            // Make sure we don't have anything downloading already
            Assert.Empty(Process.GetProcessesByName("yt-dlp"));
            Assert.Empty(Process.GetProcessesByName("ffmpeg"));

            // Start download
            youtubeDl.DownloadAsync();
            DateTime start = DateTime.Now;

            // Wait for download process to start
            while (youtubeDl.IsDownloading == false && DateTime.Now - start < timeout) {}
            // There's still a delay before the download actually starts
            while (Directory.GetFiles(outDir).Any(f => f.Contains(".part")) == false && DateTime.Now - start < timeout) {}
            TimeSpan elapsed = DateTime.Now - start;
            Assert.True(elapsed < timeout, "Download timed out");

            // Should have 2 processes, one wrapper process (see here: https://github.com/yt-dlp/yt-dlp/issues/661), and the actual download one
            Assert.Equal(2, Process.GetProcessesByName("yt-dlp").Length);

            youtubeDl.CancelDownload();

            // Shouldn't have any more download processes 
            Assert.Empty(Process.GetProcessesByName("yt-dlp"));
            Assert.Empty(Process.GetProcessesByName("ffmpeg"));

            // Cleanup 
            try
            {
                List<Process> processes = Process.GetProcessesByName("yt-dlp").ToList();
                processes.AddRange(Process.GetProcessesByName("ffmpeg"));
                if (processes.Any())
                    foreach (Process process in processes)
                        process.Kill();

                Directory.Delete(outDir, true);
            }
            catch { /* ignored */ }
        }
    }
}