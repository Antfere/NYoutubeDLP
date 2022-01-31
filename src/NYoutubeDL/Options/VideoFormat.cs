// Copyright 2021 Brian Allred
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
    ///     Object containing Video Format parameters
    /// </summary>
    public class VideoFormat : OptionSection
    {

        // Not required:
        // --no-format-sort-force
        // --no-video-multistreams
        // --no-audio-multistreams
        // --no-prefer-free-formats
        // --no-check-formats
        // --list-formats-as-table Default true
        // --no-allow-unplayable-formats

        // New:
        // --format-sort string
        // --format-sort-force bool
        // --video-multistreams
        // --audio-multistreams
        // --check-formats string
        // --check-all-formats
        // --no-list-formats-as-table
        // --allow-unplayable-formats

        [Option] internal readonly BoolOption allFormats = new BoolOption("--all-formats");

        [Option] internal readonly EnumOption<Enums.VideoFormat> format = new EnumOption<Enums.VideoFormat>("-f");

        // Just use this advanced version, not sure what the enumOption is for
        [Option] internal readonly StringOption formatAdvanced = new StringOption("-f");

        [Option] internal readonly BoolOption listFormats = new BoolOption("-F");

        [Option]
        internal readonly EnumOption<Enums.VideoFormat> mergeOutputFormat =
            new EnumOption<Enums.VideoFormat>("--merge-output-format");

        [Option] internal readonly BoolOption preferFreeFormats = new BoolOption("--prefer-free-formats");

        [Option] internal readonly BoolOption youtubeSkipDashManifest = new BoolOption("--youtube-skip-dash-manifest");

        [Option] internal readonly StringOption formatSort = new StringOption("--format-sort");

        [Option] internal readonly BoolOption formatSortForce = new BoolOption("--format-sort-force");

        [Option] internal readonly BoolOption videoMultistreams = new BoolOption("--video-multistreams");

        [Option] internal readonly BoolOption audioMultistreams = new BoolOption("--audio-multistreams");

        [Option] internal readonly StringOption checkFormats = new StringOption("--check-formats");

        [Option] internal readonly BoolOption checkAllFormats = new BoolOption("--check-all-formats");

        [Option] internal readonly BoolOption noListFormatsAsTable = new BoolOption("--no-list-formats-as-table");

        [Option] internal readonly BoolOption allowUnplayableFormats = new BoolOption("--allow-unplayable-formats");

        /// <summary>
        ///     --all-formats
        /// </summary>
        public bool AllFormats
        {
            get => this.allFormats.Value ?? false;
            set => this.SetField(ref this.allFormats.Value, value);
        }

        /// <summary>
        ///     This is a simple version of -f. For more advanced format usage, use the FormatAdvanced
        ///     property.
        ///     NOTE: FormatAdvanced takes precedence over Format. Just use the advanced version...
        /// </summary>
        public Enums.VideoFormat Format
        {
            get => this.format.Value == null ? Enums.VideoFormat.undefined : (Enums.VideoFormat)this.format.Value;
            set => this.SetField(ref this.format.Value, (int)value);
        }

        /// <summary>
        ///     This accepts a string matching -f according to the youtube-dl documentation below.
        ///     NOTE: FormatAdvanced takes precedence over Format.
        ///     <see cref="https://github.com/rg3/youtube-dl/blob/master/README.md#format-selection" />
        /// </summary>
        public string FormatAdvanced
        {
            get => this.formatAdvanced.Value;
            set => this.SetField(ref this.formatAdvanced.Value, value);
        }

        /// <summary>
        ///     -F
        /// </summary>
        public bool ListFormats
        {
            get => this.listFormats.Value ?? false;
            set => this.SetField(ref this.listFormats.Value, value);
        }

        /// <summary>
        ///     --merge-output-format
        /// </summary>
        public Enums.VideoFormat MergeOutputFormat
        {
            get => this.mergeOutputFormat.Value == null
                ? Enums.VideoFormat.undefined
                : (Enums.VideoFormat)this.mergeOutputFormat.Value;
            set => this.SetField(ref this.mergeOutputFormat.Value, (int)value);
        }

        /// <summary>
        ///     --prefer-free-formats
        /// </summary>
        public bool PreferFreeFormats
        {
            get => this.preferFreeFormats.Value ?? false;
            set => this.SetField(ref this.preferFreeFormats.Value, value);
        }

        /// <summary>
        ///     --youtube-skip-dash-manifest
        /// </summary>
        public bool YoutubeSkipDashManifest
        {
            get => this.youtubeSkipDashManifest.Value ?? false;
            set => this.SetField(ref this.youtubeSkipDashManifest.Value, value);
        }

        /// <summary>
        ///     --format-sort
        /// </summary>
        public string FormatSort
        {
            get => this.formatSort.Value;
            set => this.SetField(ref this.formatSort.Value, value);
        }

        /// <summary>
        ///     --format-sort-force
        /// </summary>
        public bool FormatSortForce
        {
            get => this.formatSortForce.Value ?? false;
            set => this.SetField(ref this.formatSortForce.Value, value);
        }

        /// <summary>
        ///     --video-multistreams
        /// </summary>
        public bool VideoMultistreams
        {
            get => this.videoMultistreams.Value ?? false;
            set => this.SetField(ref this.videoMultistreams.Value, value);
        }

        /// <summary>
        ///     --audio-multistreams
        /// </summary>
        public bool AudioMultistreams
        {
            get => this.audioMultistreams.Value ?? false;
            set => this.SetField(ref this.audioMultistreams.Value, value);
        }

        /// <summary>
        ///     --check-formats
        /// </summary>
        public string CheckFormats
        {
            get => this.checkFormats.Value;
            set => this.SetField(ref this.checkFormats.Value, value);
        }

        /// <summary>
        ///     --check-all-formats
        /// </summary>
        public bool CheckAllFormats
        {
            get => this.checkAllFormats.Value ?? false;
            set => this.SetField(ref this.checkAllFormats.Value, value);
        }

        /// <summary>
        ///     --no-list-formats-as-table
        /// </summary>
        public bool NoListFormatsAsTable
        {
            get => this.noListFormatsAsTable.Value ?? false;
            set => this.SetField(ref this.noListFormatsAsTable.Value, value);
        }

        /// <summary>
        ///     --allow-unplayable-formats
        /// </summary>
        public bool AllowUnplayableFormats
        {
            get => this.allowUnplayableFormats.Value ?? false;
            set => this.SetField(ref this.allowUnplayableFormats.Value, value);
        }

        public override string ToCliParameters()
        {
            // Set format to null if formatAdvanced has a valid value
            if (!string.IsNullOrWhiteSpace(this.formatAdvanced.Value))
            {
                this.format.Value = null;
            }

            return base.ToCliParameters();
        }
    }
}