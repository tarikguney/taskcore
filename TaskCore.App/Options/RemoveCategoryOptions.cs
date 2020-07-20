using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class RemoveCategoryOptions : VerbOptionsBase
    {
        [OptionName("title", Alias = "t")]
        public string CategoryName { get; set; }
    }
}