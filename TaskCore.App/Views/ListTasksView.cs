using System;
using System.Collections.Generic;
using System.Linq;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Models;
using static System.Console;

namespace TaskCore.App.Views
{
    public class ListTasksView : VerbViewBase
    {
        private readonly ListTasksOptions _options;
        private readonly IReadOnlyList<TodoTask> _activeTasks;
        private readonly IReadOnlyList<TodoTask> _completedTasks;
        private readonly Dictionary<string, string> _categoriesDict;
        private readonly IPriorityColorChooser _priorityColorChooser;

        public ListTasksView(ListTasksOptions options, IReadOnlyList<TodoTask> activeTasks,
            IReadOnlyList<TodoTask> completedTasks, IReadOnlyList<Category> categories,
            IPriorityColorChooser priorityColorChooser)
        {
            _options = options;
            _activeTasks = activeTasks;
            _completedTasks = completedTasks;
            _categoriesDict = categories.ToDictionary(a => a.CategoryId, a => a.Name);
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
            foreach (var task in _completedTasks)
            {
                Write($"- [X] \"{task.Title}\" {task.Priority} in {_categoriesDict[task.CategoryId]}");
                if (_options.Verbose)
                {
                    Write($" - Created at {task.CreationDate:F}, completed at {task.CompletionDate:F}");
                }

                WriteLine();
            }
        }

        private void RenderActiveTasks()
        {
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
                Write($"in {_categoriesDict[task.CategoryId]}");
                if (_options.Verbose)
                {
                    Write($" - {task.CreationDate:F}.");
                }

                WriteLine();
            }
        }
    }
}