using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("rm")]
    public class RemoveTask : VerbBase<RemoveTaskOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public RemoveTask(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}