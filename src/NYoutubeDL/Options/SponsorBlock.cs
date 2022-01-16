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

        [Option] internal readonly StringOption sponsorblockChapterTitle = new StringOption("--sponsorblock-chapter-title");

        [Option] internal readonly BoolOption noSponsorblock = new BoolOption("--no-sponsorblock");

        [Option] internal readonly StringOption sponsorblockAPI = new StringOption("--sponsorblock-api");

        [Option] internal readonly BoolOption sponskrub = new BoolOption("--sponskrub");

        [Option] internal readonly BoolOption noSponskrub = new BoolOption("--no-sponskrub");

        [Option] internal readonly BoolOption sponskrubCut = new BoolOption("--sponskrub-cut");

        [Option] internal readonly BoolOption noSponskrubCut = new BoolOption("--no-sponskrub-cut");

        [Option] internal readonly BoolOption sponskrubForce = new BoolOption("--sponskrub-force");

        [Option] internal readonly BoolOption noSponskrubForce = new BoolOption("--no-sponskrub-force");

        [Option] internal readonly StringOption sponskrubLocation = new StringOption("--sponskrub-location");

        [Option] internal readonly StringOption sponskrubArgs = new StringOption("--sponskrub-args");

        /// <summary>
        ///     --autonumber-size
        /// </summary>
        public string SponsorblockMark
        {
            get => this.sponsorblockMark.Value;
            set => this.SetField(ref this.sponsorblockMark.Value, value);
        }

        /// <summary>
        ///     --autonumber-start
        /// </summary>
        public string SponsorblockRemove
        {
            get => this.sponsorblockRemove.Value;
            set => this.SetField(ref this.sponsorblockRemove.Value, value);
        }

        /// <summary>
        ///     -a
        /// </summary>
        public string SponsorblockChapterTitle
        {
            get => this.sponsorblockChapterTitle.Value;
            set => this.SetField(ref this.sponsorblockChapterTitle.Value, value);
        }

        /// <summary>
        ///     --cache-dir
        /// </summary>
        public bool NoSponsorblock
        {
            get => this.noSponsorblock.Value ?? false;
            set => this.SetField(ref this.noSponsorblock.Value, value);
        }

        /// <summary>
        ///     -c
        /// </summary>
        public string SponsorblockAPI
        {
            get => this.sponsorblockAPI.Value;
            set => this.SetField(ref this.sponsorblockAPI.Value, value);
        }

        /// <summary>
        ///     --cookies
        /// </summary>
        public bool Sponskrub
        {
            get => this.sponskrub.Value ?? false;
            set => this.SetField(ref this.sponskrub.Value, value);
        }

        /// <summary>
        ///     --id
        /// </summary>
        public bool NoSponskrub
        {
            get => this.noSponskrub.Value ?? false;
            set => this.SetField(ref this.noSponskrub.Value, value);
        }

        /// <summary>
        ///     --load-info-json
        /// </summary>
        public bool SponskrubCut
        {
            get => this.sponskrubCut.Value ?? false;
            set => this.SetField(ref this.sponskrubCut.Value, value);
        }

        /// <summary>
        ///     --no-cache-dir
        /// </summary>
        public bool NoSponskrubCut
        {
            get => this.noSponskrubCut.Value ?? false;
            set => this.SetField(ref this.noSponskrubCut.Value, value);
        }

        /// <summary>
        ///     --no-continue
        /// </summary>
        public bool SponskrubForce
        {
            get => this.sponskrubForce.Value ?? false;
            set => this.SetField(ref this.sponskrubForce.Value, value);
        }

        /// <summary>
        ///     --no-mtime
        /// </summary>
        public bool NoSponskrubForce
        {
            get => this.noSponskrubForce.Value ?? false;
            set => this.SetField(ref this.noSponskrubForce.Value, value);
        }

        /// <summary>
        ///     -w
        /// </summary>
        public string SponskrubLocation
        {
            get => this.sponskrubLocation.Value;
            set => this.SetField(ref this.sponskrubLocation.Value, value);
        }

        /// <summary>
        ///     --no-part
        /// </summary>
        public string SponskrubArgs
        {
            get => this.sponskrubArgs.Value;
            set => this.SetField(ref this.sponskrubArgs.Value, value);
        }
    }
}