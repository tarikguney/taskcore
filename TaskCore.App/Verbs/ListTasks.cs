using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("list", Description = "Lists all of the tasks.")]
    public class ListTasks : VerbBase<ListTasksOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public ListTasks(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}