using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("c")]
    public class CompleteTask: VerbBase<CompleteTaskOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public CompleteTask(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}