using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;

namespace TaskCore.App.Verbs
{
    [VerbName("add")]
    public class AddTask : VerbBase<AddTaskOptions>
    {
        public override VerbViewBase Run()
        {
            // TODO Change this with an actual implementation. Testing here for now.
            return new AddTaskView(
                $"Title: {Options.Title}\nPriority: {Options.Priority}\nCategory: {Options.Category}\nDue Date: {Options.DueDate}");
        }
    }
}