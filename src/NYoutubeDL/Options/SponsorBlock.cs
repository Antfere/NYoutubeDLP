namespace NYoutubeDL.Options
{
    #region Using

    using System.Linq;
    using Helpers;

    #endregion

    /// <summary>
    ///     Object containing SponsorBlock parameters
    /// </summary>
    public class SponsorBlock : OptionSection
    {
        [Option] internal readonly StringOption sponsorblockMark = new StringOption("--sponsorblock-mark");

        [Option] internal readonly StringOption sponsorblockRemove = new StringOption("--sponsorblock-remove");

        // No need for --no-sponsorblock option, just don't use the above two.

        [Option] internal readonly StringOption sponsorblockChapterTitle = new StringOption("--sponsorblock-chapter-title");

        [Option] internal readonly StringOption sponsorblockAPI = new StringOption("--sponsorblock-api");

        [Option] internal readonly BoolOption sponskrub = new BoolOption("--sponskrub");

        [Option] internal readonly BoolOption sponskrubCut = new BoolOption("--sponskrub-cut");

        [Option] internal readonly BoolOption sponskrubForce = new BoolOption("--sponskrub-force");

        [Option] internal readonly StringOption sponskrubLocation = new StringOption("--sponskrub-location");

        [Option] internal readonly StringOption sponskrubArgs = new StringOption("--sponskrub-args");

        /// <summary>
        ///     --sponsorblock-mark
        /// </summary>
        public string SponsorblockMark
        {
            get => this.sponsorblockMark.Value;
            set => this.SetField(ref this.sponsorblockMark.Value, value);
        }

        /// <summary>
        ///     --sponsorblock-remove
        /// </summary>
        public string SponsorblockRemove
        {
            get => this.sponsorblockRemove.Value;
            set => this.SetField(ref this.sponsorblockRemove.Value, value);
        }

        /// <summary>
        ///     --sponsorblock-chapter-title
        /// </summary>
        public string SponsorblockChapterTitle
        {
            get => this.sponsorblockChapterTitle.Value;
            set => this.SetField(ref this.sponsorblockChapterTitle.Value, value);
        }

        /// <summary>
        ///     --sponsorblock-api
        /// </summary>
        public string SponsorblockAPI
        {
            get => this.sponsorblockAPI.Value;
            set => this.SetField(ref this.sponsorblockAPI.Value, value);
        }

        /// <summary>
        ///     --sponskrub
        /// </summary>
        public bool Sponskrub
        {
            get => this.sponskrub.Value ?? false;
            set => this.SetField(ref this.sponskrub.Value, value);
        }

        /// <summary>
        ///     --sponskrub-cut
        /// </summary>
        public bool SponskrubCut
        {
            get => this.sponskrubCut.Value ?? false;
            set => this.SetField(ref this.sponskrubCut.Value, value);
        }

        /// <summary>
        ///     --sponskrub-force
        /// </summary>
        public bool SponskrubForce
        {
            get => this.sponskrubForce.Value ?? false;
            set => this.SetField(ref this.sponskrubForce.Value, value);
        }

        /// <summary>
        ///     --sponskrub-location
        /// </summary>
        public string SponskrubLocation
        {
            get => this.sponskrubLocation.Value;
            set => this.SetField(ref this.sponskrubLocation.Value, value);
        }

        /// <summary>
        ///     --sponskrub-args
        /// </summary>
        public string SponskrubArgs
        {
            get => this.sponskrubArgs.Value;
            set => this.SetField(ref this.sponskrubArgs.Value, value);
        }
    }
}