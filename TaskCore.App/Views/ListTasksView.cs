using System.Collections.Generic;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Models;
using static System.Console;

namespace TaskCore.App.Views
{
    public class ListTasksView : VerbViewBase
    {
        private readonly IReadOnlyList<TodoTask> _tasks;
        private readonly ListTasksOptions _options;
        private readonly IPriorityColorChooser _priorityColorChooser;

        public ListTasksView(IReadOnlyList<TodoTask> tasks,IPriorityColorChooser priorityColorChooser)
        {
            _tasks = tasks;
            _priorityColorChooser = priorityColorChooser;
        }

        public override void RenderResponse()
        {
            for (var i = 0; i < _tasks.Count; i++)
            {
                var task = _tasks[i];
                var usePriorityColor = task.Priority > 0 && task.Priority < 4;
                if (usePriorityColor)
                {
                    ForegroundColor = _priorityColorChooser.GetColor(task.Priority);
                }

                var completed = task.Completed ? "X" : " ";
                Write($"[{completed}]");
                ResetColor();
                Write(" ");
                Write($"{i}. \"{task.Title}\"");
                Write(" ");
                
                if (usePriorityColor)
                {
                    ForegroundColor = _priorityColorChooser.GetColor(task.Priority);
                }

                Write($"P{task.Priority}");
                ResetColor();
                Write(" ");
                WriteLine($"in {task.CategoryId}");
            }
        }
    }
}