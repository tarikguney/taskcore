using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class AddTaskOptions : VerbOptionsBase
    {
        [OptionName("title", Alias = "t")]
        public string Title { get; set; }

        [OptionName("duedate", Alias = "d")]
        public string DueDate { get; set; }

        [OptionName("priority", Alias = "p")]
        public int Priority { get; set; }

        [OptionName("category", Alias = "c")]
        public string Category { get; set; }
        
        [OptionName("completed", Alias = "cm")]
        public bool Completed { get; set; }
    }
}