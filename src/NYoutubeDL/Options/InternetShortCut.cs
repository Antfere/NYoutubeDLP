namespace NYoutubeDL.Options
{
    #region Using

    using System.Linq;
    using Helpers;

    #endregion

    /// <summary>
    ///     Object containing InternetShortCut parameters
    /// </summary>
    public class InternetShortCut : OptionSection
    {
        [Option] internal readonly BoolOption writeLink = new BoolOption("--write-info-json");

        [Option] internal readonly BoolOption writeUrlLink = new BoolOption("--write-info-json");

        [Option] internal readonly BoolOption writeWeblocLink = new BoolOption("--write-info-json");

        [Option] internal readonly BoolOption writeDesktopLink = new BoolOption("--write-desktop-link");

        /// <summary>
        ///     --write-info-json
        /// </summary>
        public bool WriteLink
        {
            get => this.writeLink.Value ?? false;
            set => this.SetField(ref this.writeLink.Value, value);
        }

        /// <summary>
        ///     --write-info-json
        /// </summary>
        public bool WriteUrlLink
        {
            get => this.writeUrlLink.Value ?? false;
            set => this.SetField(ref this.writeUrlLink.Value, value);
        }

        /// <summary>
        ///     --write-info-json
        /// </summary>
        public bool WriteWeblocLink
        {
            get => this.writeWeblocLink.Value ?? false;
            set => this.SetField(ref this.writeWeblocLink.Value, value);
        }

        /// <summary>
        ///     --write-desktop-link
        /// </summary>
        public bool WriteDesktopLink
        {
            get => this.writeDesktopLink.Value ?? false;
            set => this.SetField(ref this.writeDesktopLink.Value, value);
        }
    }
}