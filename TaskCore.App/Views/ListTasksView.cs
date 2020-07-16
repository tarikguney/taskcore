using System.Collections.Generic;
using CommandCore.Library.PublicBase;
using TaskCore.Dal.Models;
using static System.Console;

namespace TaskCore.App.Views
{
    public class ListTasksView : VerbViewBase
    {
        private readonly IReadOnlyList<TodoTask> _tasks;
        private readonly IPriorityColorChooser _priorityColorChooser;

        public ListTasksView(IReadOnlyList<TodoTask> tasks, IPriorityColorChooser priorityColorChooser)
        {
            _tasks = tasks;
            _priorityColorChooser = priorityColorChooser;
        }

        public override void RenderResponse()
        {
            foreach (var task in _tasks)
            {
                ForegroundColor = _priorityColorChooser.GetColor(task.Priority);
                var completed = task.Completed ? "X" : " ";
                Write($"[{completed}]");
                ResetColor();
                Write(" ");
                // TODO show the order number as the ID instead of the actual ID.
                Write($"{task.Id}. \"{task.Title}\"");
                Write(" ");
                ForegroundColor = _priorityColorChooser.GetColor(task.Priority);
                Write($"P{task.Priority}");
                ResetColor();
                Write(" ");
                WriteLine($"in {task.CategoryId}");
            }
        }
    }
}