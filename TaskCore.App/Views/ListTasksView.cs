using System;
using System.Collections.Generic;
using CommandCore.Library.PublicBase;
using TaskCore.Dal.Models;
using static System.Console;

namespace TaskCore.App.Views
{
    public class ListTasksView : VerbViewBase
    {
        private readonly IReadOnlyList<TodoTask> _activeTasks;
        private readonly IReadOnlyList<TodoTask> _completedTasks;
        private readonly IPriorityColorChooser _priorityColorChooser;

        public ListTasksView(IReadOnlyList<TodoTask> activeTasks, IReadOnlyList<TodoTask> completedTasks,
            IPriorityColorChooser priorityColorChooser)
        {
            _activeTasks = activeTasks;
            _completedTasks = completedTasks;
            _priorityColorChooser = priorityColorChooser;
        }

        public override void RenderResponse()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("[ ] ACTIVE TASKS:");
            ResetColor();
            WriteLine("-----------------");
            RenderActiveTasks();
            if (_completedTasks.Count > 0)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                WriteLine("[✓] COMPLETED TASKS:");
                ResetColor();
                WriteLine("-----------------");
                RenderCompletedTasks();
            }
        }

        private void RenderCompletedTasks()
        {
            // TODO need to capture display the completion and creation dates.
            // TODO Use CategoryId to get the actual category title and show it instead.
            foreach (var task in _completedTasks)
            {
                WriteLine($"- [X] \"{task.Title}\" {task.Priority} in {task.CategoryId}");
            }
        }

        private void RenderActiveTasks()
        {
            // TODO Need to display the task creation date.
            for (var i = 0; i < _activeTasks.Count; i++)
            {
                var task = _activeTasks[i];
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
                // TODO Outputting the CategoryId is not correct. Use Category Title instead.
                WriteLine($"in {task.CategoryId}");
            }
        }
    }
}