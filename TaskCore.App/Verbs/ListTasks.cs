using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("ls", Description = "Lists all of the tasks.")]
    public class ListTasks : VerbBase<ListTasksOptions>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IPriorityColorChooser _priorityColorChooser;

        public ListTasks(ITodoTaskRepository todoTaskRepository, IPriorityColorChooser priorityColorChooser)
        {
            _todoTaskRepository = todoTaskRepository;
            _priorityColorChooser = priorityColorChooser;
        }

        public override VerbViewBase Run()
        {
            var allTasks = _todoTaskRepository.GetAll();
            return new ListTasksView(allTasks, _priorityColorChooser);
        }
    }
}