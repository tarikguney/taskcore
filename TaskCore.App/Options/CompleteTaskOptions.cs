using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class CompleteTaskOptions : VerbOptionsBase
    {
        [OptionName("taskId", Alias = "i")]
        public int[] TaskIds { get; set; }
    }
}