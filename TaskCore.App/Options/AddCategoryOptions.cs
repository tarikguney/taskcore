using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class AddCategoryOptions : VerbOptionsBase
    {
        [OptionName("name", Alias="n")]
        public string Name { get; set; }
        
        [OptionName("color", Alias = "c")]
        public string Color { get; set; }
    }
}