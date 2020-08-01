using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class AddTaskOptions : VerbOptionsBase
    {
        [OptionName("title", Alias = "t", Description = "Title of the task.")]
        [OptionName("name", Alias = "n", Description = "Name of the task.")]
        public string Title { get; set; }

        [OptionName("duedate", Alias = "d", Description = "01/01/2010, 15(Adds 15 days from today and selects it), today, tomorrow, nextweek or \"next week\", nextmonth or \"next month\"")]
        public string DueDate { get; set; }

        [OptionName("priority", Alias = "p")]
        public int Priority { get; set; } = 4;

        [OptionName("category", Alias = "c")]
        public string Category { get; set; } = "Inbox";

        [OptionName("completed", Alias = "cm")]
        public bool Completed { get; set; }
    }
}