using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class ListTasksOptions: VerbOptionsBase
    {
        [OptionName("showcompleted", Alias = "c")]
        public bool ShowCompletedTasks { get; set; }
        
        [OptionName("verbose",Alias = "v")]
        public bool Verbose { get; set; }
        
        [OptionName("category", Alias="ca")]
        public string CategoryName { get; set; }
    }
}