using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class RemoveTaskOptions : VerbOptionsBase
    {
        [OptionName("id", Alias = "i")]
        public int TaskOrder { get; set; }
    }
}