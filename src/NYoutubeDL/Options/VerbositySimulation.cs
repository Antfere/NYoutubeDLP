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

namespace NYoutubeDL.Options
{
    #region Using

    using Helpers;

    #endregion

    /// <summary>
    ///     Object containing Verbosity and Simulation parameters
    /// </summary>
    public class VerbositySimulation : OptionSection
    {

        // Not Required:
        // --no-simulate
        // --no-ignore-no-formats-error

        // New:
        // --ignore-no-formats-error
        // print string
        // --force-write-download-archive
        // --progress
        // --progress-template string

        // --print-to-file string

        [Option] internal readonly BoolOption callHome = new BoolOption("-C");

        [Option] internal readonly BoolOption consoleTitle = new BoolOption("--console-title");

        [Option] internal readonly BoolOption dumpJson = new BoolOption("-j");

        [Option] internal readonly BoolOption dumpPages = new BoolOption("--dump-pages");

        [Option] internal readonly BoolOption dumpSingleJson = new BoolOption("-J");

        [Option] internal readonly BoolOption getDescription = new BoolOption("--get-description");

        [Option] internal readonly BoolOption getDuration = new BoolOption("--get-duration");

        [Option] internal readonly BoolOption getFilename = new BoolOption("--get-filename");

        [Option] internal readonly BoolOption getFormat = new BoolOption("--get-format");

        [Option] internal readonly BoolOption getId = new BoolOption("--get-id");

        [Option] internal readonly BoolOption getThumbnail = new BoolOption("--get-thumbnail");

        [Option] internal readonly BoolOption getTitle = new BoolOption("-e");

        [Option] internal readonly BoolOption getUrl = new BoolOption("-g");

        [Option] internal readonly BoolOption newline = new BoolOption("--newline");

        [Option] internal readonly BoolOption noCallHome = new BoolOption("--no-call-home");

        [Option] internal readonly BoolOption noProgress = new BoolOption("--no-progress");

        [Option] internal readonly BoolOption noWarnings = new BoolOption("--no-warnings");

        [Option] internal readonly BoolOption printJson = new BoolOption("--print-jobs");

        [Option] internal readonly BoolOption printTraffic = new BoolOption("--print-traffic");

        [Option] internal readonly BoolOption quiet = new BoolOption("-q");

        [Option] internal readonly BoolOption simulate = new BoolOption("-s");

        [Option] internal readonly BoolOption skipDownload = new BoolOption("--skip-download");

        [Option] internal readonly BoolOption verbose = new BoolOption("-v");

        [Option] internal readonly BoolOption writePages = new BoolOption("--write-pages");

        [Option] internal readonly BoolOption ignoreNoFormatsError = new BoolOption("--ignore-no-formats-error");

        [Option] internal readonly StringOption print = new StringOption("--print");

        [Option] internal readonly BoolOption forceWriteDownloadArchive = new BoolOption("--force-write-download-archive");

        [Option] internal readonly BoolOption progress = new BoolOption("--progress");

        [Option] internal readonly StringOption progressTemplate = new StringOption("--progress-template");

        [Option] internal readonly StringOption printToFile = new StringOption("--print-to-file");

        /// <summary>
        ///     -C
        /// </summary>
        public bool CallHome
        {
            get => this.callHome.Value ?? false;
            set => this.SetField(ref this.callHome.Value, value);
        }

        /// <summary>
        ///     --console-title
        /// </summary>
        public bool ConsoleTitle
        {
            get => this.consoleTitle.Value ?? false;
            set => this.SetField(ref this.consoleTitle.Value, value);
        }

        /// <summary>
        ///     -j
        /// </summary>
        public bool DumpJson
        {
            get => this.dumpJson.Value ?? false;
            set => this.SetField(ref this.dumpJson.Value, value);
        }

        /// <summary>
        ///     --dump-pages
        /// </summary>
        public bool DumpPages
        {
            get => this.dumpPages.Value ?? false;
            set => this.SetField(ref this.dumpPages.Value, value);
        }

        /// <summary>
        ///     -J
        /// </summary>
        public bool DumpSingleJson
        {
            get => this.dumpSingleJson.Value ?? false;
            set => this.SetField(ref this.dumpSingleJson.Value, value);
        }

        /// <summary>
        ///     --get-description
        /// </summary>
        public bool GetDescription
        {
            get => this.getDescription.Value ?? false;
            set => this.SetField(ref this.getDescription.Value, value);
        }

        /// <summary>
        ///     --get-duration
        /// </summary>
        public bool GetDuration
        {
            get => this.getDuration.Value ?? false;
            set => this.SetField(ref this.getDuration.Value, value);
        }

        /// <summary>
        ///     --get-filename
        /// </summary>
        public bool GetFilename
        {
            get => this.getFilename.Value ?? false;
            set => this.SetField(ref this.getFilename.Value, value);
        }

        /// <summary>
        ///     --get-format
        /// </summary>
        public bool GetFormat
        {
            get => this.getFormat.Value ?? false;
            set => this.SetField(ref this.getFormat.Value, value);
        }

        /// <summary>
        ///     --get-id
        /// </summary>
        public bool GetId
        {
            get => this.getId.Value ?? false;
            set => this.SetField(ref this.getId.Value, value);
        }

        /// <summary>
        ///     --get-thumbnail
        /// </summary>
        public bool GetThumbnail
        {
            get => this.getThumbnail.Value ?? false;
            set => this.SetField(ref this.getThumbnail.Value, value);
        }

        /// <summary>
        ///     -e
        /// </summary>
        public bool GetTitle
        {
            get => this.getTitle.Value ?? false;
            set => this.SetField(ref this.getTitle.Value, value);
        }

        /// <summary>
        ///     -g
        /// </summary>
        public bool GetUrl
        {
            get => this.getUrl.Value ?? false;
            set => this.SetField(ref this.getUrl.Value, value);
        }

        /// <summary>
        ///     --newline
        /// </summary>
        public bool Newline
        {
            get => this.newline.Value ?? false;
            set => this.SetField(ref this.newline.Value, value);
        }

        /// <summary>
        ///     --no-call-home
        /// </summary>
        public bool NoCallHome
        {
            get => this.noCallHome.Value ?? false;
            set => this.SetField(ref this.noCallHome.Value, value);
        }

        /// <summary>
        ///     --no-progress
        /// </summary>
        public bool NoProgress
        {
            get => this.noProgress.Value ?? false;
            set => this.SetField(ref this.noProgress.Value, value);
        }

        /// <summary>
        ///     --no-warnings
        /// </summary>
        public bool NoWarnings
        {
            get => this.noWarnings.Value ?? false;
            set => this.SetField(ref this.noWarnings.Value, value);
        }

        /// <summary>
        ///     --print-json
        /// </summary>
        public bool PrintJson
        {
            get => this.printJson.Value ?? false;
            set => this.SetField(ref this.printJson.Value, value);
        }

        /// <summary>
        ///     --print-traffic
        /// </summary>
        public bool PrintTraffic
        {
            get => this.printTraffic.Value ?? false;
            set => this.SetField(ref this.printTraffic.Value, value);
        }

        /// <summary>
        ///     -q
        /// </summary>
        public bool Quiet
        {
            get => this.quiet.Value ?? false;
            set => this.SetField(ref this.quiet.Value, value);
        }

        /// <summary>
        ///     -s
        /// </summary>
        public bool Simulate
        {
            get => this.simulate.Value ?? false;
            set => this.SetField(ref this.simulate.Value, value);
        }

        /// <summary>
        ///     --skip-download
        /// </summary>
        public bool SkipDownload
        {
            get => this.skipDownload.Value ?? false;
            set => this.SetField(ref this.skipDownload.Value, value);
        }

        /// <summary>
        ///     -v
        /// </summary>
        public bool Verbose
        {
            get => this.verbose.Value ?? false;
            set => this.SetField(ref this.verbose.Value, value);
        }

        /// <summary>
        ///     --write-pages
        /// </summary>
        public bool WritePages
        {
            get => this.writePages.Value ?? false;
            set => this.SetField(ref this.writePages.Value, value);
        }

        /// <summary>
        ///     --ignore-no-formats-error
        /// </summary>
        public bool IgnoreNoFormatsError
        {
            get => this.ignoreNoFormatsError.Value ?? false;
            set => this.SetField(ref this.ignoreNoFormatsError.Value, value);
        }

        /// <summary>
        ///     --print
        /// </summary>
        public string Print
        {
            get => this.print.Value;
            set => this.SetField(ref this.print.Value, value);
        }

        /// <summary>
        ///     --force-write-download-archive
        /// </summary>
        public bool ForceWriteDownloadArchive
        {
            get => this.forceWriteDownloadArchive.Value ?? false;
            set => this.SetField(ref this.forceWriteDownloadArchive.Value, value);
        }

        /// <summary>
        ///     --progress
        /// </summary>
        public bool Progress
        {
            get => this.progress.Value ?? false;
            set => this.SetField(ref this.progress.Value, value);
        }

        /// <summary>
        ///     --progress-template
        /// </summary>
        public string ProgressTemplate
        {
            get => this.progressTemplate.Value;
            set => this.SetField(ref this.progressTemplate.Value, value);
        }

        /// <summary>
        ///     --print-to-file
        /// </summary>
        public string PrintToFile
        {
            get => this.printToFile.Value;
            set => this.SetField(ref this.printToFile.Value, value);
        }
    }
}