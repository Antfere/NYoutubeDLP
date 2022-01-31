namespace NYoutubeDL.Options
{
    #region Using

    using System.Linq;
    using Helpers;

    #endregion

    /// <summary>
    ///     Object containing Extractor parameters
    /// </summary>
    public class Extractor : OptionSection
    {
        // Number of retries for known extractor errors
        [Option] internal readonly IntOption extractorRetries = new IntOption("--extractor-retries");
        // Process dynamic DASH manifests
        [Option] internal readonly BoolOption allowDynamicMpd = new BoolOption("--allow-dynamic-mpd");

        // Should be kept as the positive option has no off switch
        [Option] internal readonly BoolOption ignoreDynamicMpd = new BoolOption("--ignore-dynamic-mpd");

        [Option] internal readonly BoolOption hlsSplitDiscontinuity = new BoolOption("--hls-split-discontinuity");

        // --no-hls-split-discontinuity not required, positive option off by default.

        // Pass these arguments to the extractor. See "EXTRACTOR ARGUMENTS" for details.
        [Option] internal readonly StringOption extractorArgs = new StringOption("--extractor-args");

        [Option] internal readonly BoolOption youtubeIncludeDashManifest = new BoolOption("--youtube-include-dash-manifest");

        // Necessary
        [Option] internal readonly BoolOption youtubeSkipDashManifest = new BoolOption("--youtube-skip-dash-manifest");

        [Option] internal readonly BoolOption youtubeIncludeHlsManifest = new BoolOption("--youtube-include-hls-manifest");

        // Necessary
        [Option] internal readonly BoolOption youtubeSkipHlsManifest = new BoolOption("--youtube-skip-hls-manifest");

        /// <summary>
        ///     --extractor-retries
        /// </summary>
        public int ExtractorRetries
        {
            get => this.extractorRetries.Value ?? 3;
            set => this.SetField(ref this.extractorRetries.Value, value);
        }

        /// <summary>
        ///     --allow-dynamic-mpd
        /// </summary>
        public bool AllowDynamicMpd
        {
            get => this.allowDynamicMpd.Value ?? false;
            set => this.SetField(ref this.allowDynamicMpd.Value, value);
        }

        /// <summary>
        ///     --ignore-dynamic-mpd
        /// </summary>
        public bool IgnoreDynamicMpd
        {
            get => this.ignoreDynamicMpd.Value ?? false;
            set => this.SetField(ref this.ignoreDynamicMpd.Value, value);
        }

        /// <summary>
        ///     --hls-split-discontinuity
        /// </summary>
        public bool HlsSplitDiscontinuity
        {
            get => this.hlsSplitDiscontinuity.Value ?? false;
            set => this.SetField(ref this.hlsSplitDiscontinuity.Value, value);
        }

        /// <summary>
        ///     --extractor-args
        /// </summary>
        public string ExtractorArgs
        {
            get => this.extractorArgs.Value;
            set => this.SetField(ref this.extractorArgs.Value, value);
        }

        /// <summary>
        ///     --youtube-include-dash-manifest
        /// </summary>
        public bool YoutubeIncludeDashManifest
        {
            get => this.youtubeIncludeDashManifest.Value ?? false;
            set => this.SetField(ref this.youtubeIncludeDashManifest.Value, value);
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
        ///     --youtube-include-hls-manifest
        /// </summary>
        public bool YoutubeIncludeHlsManifest
        {
            get => this.youtubeIncludeHlsManifest.Value ?? false;
            set => this.SetField(ref this.youtubeIncludeHlsManifest.Value, value);
        }

        /// <summary>
        ///     --youtube-skip-hls-manifest
        /// </summary>
        public bool YoutubeSkipHlsManifest
        {
            get => this.youtubeSkipHlsManifest.Value ?? false;
            set => this.SetField(ref this.youtubeSkipHlsManifest.Value, value);
        }
    }
}