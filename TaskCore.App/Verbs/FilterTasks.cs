using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("filter")]
    public class FilterTasks : VerbBase<FilterTasksOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public FilterTasks(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}