using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class ClearDatabaseOptions : VerbOptionsBase
    {
        [OptionName("force")]
        public bool Force { get; set; }
    }
}
