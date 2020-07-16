using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("add")]
    public class AddTask : VerbBase<AddTaskOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public AddTask(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }
        public override VerbViewBase Run()
        {
            // TODO Change this with an actual implementation. Testing here for now.
            return new AddTaskView(
                $"Title: {Options.Title}\nPriority: {Options.Priority}\nCategory: {Options.Category}\nDue Date: {Options.DueDate}");
        }
    }
}