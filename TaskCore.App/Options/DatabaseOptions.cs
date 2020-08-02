using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class DatabaseOptions : VerbOptionsBase
    {
        [OptionName("write", Alias = "w", Description = "Writes your local database path in console")]
        public bool Write { get; set; }

        [OptionName("open", Alias = "o", Description = "Opens your local database folders with your file manager system")]
        public bool Open { get; set; }

        [OptionName("clear", Alias = "c", Description = "Removes your local database folders. You must use --force for it.")]
        public bool Clear { get; set; }

        [OptionName("force")]
        public bool Force { get; set; }

    }
}
