using System.Collections.Generic;
using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

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
            var activeTasks = _todoTaskRepository.GetActiveTasksOrderedByAddedDate();
            var completedTasks = Options.ShowCompletedTasks
                ? _todoTaskRepository.GetCompletedTasksOrderedByAddedDate()
                : new List<TodoTask>();

            return new ListTasksView(Options, activeTasks, completedTasks, _priorityColorChooser);
        }
    }
}