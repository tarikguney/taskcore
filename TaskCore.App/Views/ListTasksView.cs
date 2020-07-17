using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            for(var i = 0;i < _tasks.Count; i++)
            {
                var task = _tasks[i];
                ForegroundColor = _priorityColorChooser.GetColor(task.Priority);
                var completed = task.Completed ? "X" : " ";
                Write($"[{completed}]");
                ResetColor();
                Write(" ");
                // TODO show the order number as the ID instead of the actual ID.
                Write($"{i}. \"{task.Title}\"");
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