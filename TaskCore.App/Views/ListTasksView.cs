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
            WriteLine($"[ ] ACTIVE TASKS - Total #: {_activeTasks.Count}");
            WriteLine("--------------------------------");
            ResetColor();

            RenderActiveTasks();
            if (_completedTasks.Count > 0)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"[X] COMPLETED TASKS - Total #: {_completedTasks.Count}");
                WriteLine("----------------------------------");
                ResetColor();
                RenderCompletedTasks();
            }
        }

        private void RenderCompletedTasks()
        {
            var completedTask = _completedTasks.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(_options.CategoryName))
            {
                var categoryId = new Category() { Name = _options.CategoryName }.CategoryId;
                completedTask = completedTask.Where(a => a.CategoryId == categoryId);
            }
            if (_options.Priority != 0)
            {
                completedTask = completedTask.Where(x => x.Priority == _options.Priority).ToList();
            }

            if (completedTask.Count() == 0)
            {
                if (!string.IsNullOrWhiteSpace(_options.CategoryName) && _options.Priority != 0)
                {
                    Write("There's no Completed task with the Priority ID: {0} and the Category name: {1}", _options.Priority, _options.CategoryName);
                }
                else if(_options.Priority != 0)
                {
                    Write("There's no Completed task with the Priority ID: {0}", _options.Priority);
                }
                else if (!string.IsNullOrWhiteSpace(_options.CategoryName))
                {
                    Write("There's no Completed task with the Category name: {0}", _options.CategoryName);
                }
                else
                {
                    Write("There's no Completed task");
                }
            }

            foreach (var task in completedTask)
            {
                Write($"- [X] \"{task.Title}\" P{task.Priority} in {_categoriesDict[task.CategoryId]}");
                if (_options.Verbose)
                {
                    Write($" - Created at {task.CreationDate:F}, completed at {task.CompletionDate:F}");
                }

                WriteLine();
            }
        }

        private void RenderActiveTasks()
        {
            var activeTasks = _activeTasks;
            if (!string.IsNullOrWhiteSpace(_options.CategoryName))
            {
                var categoryId = new Category() { Name = _options.CategoryName }.CategoryId;
                activeTasks = activeTasks.Where(x => x.CategoryId == categoryId).ToList();
            }

            if (_options.Priority != 0)
            {
                activeTasks = activeTasks.Where(x => x.Priority == _options.Priority).ToList();
            }

            if (activeTasks.Count() == 0)
            {
                if (!string.IsNullOrWhiteSpace(_options.CategoryName) && _options.Priority != 0)
                {
                    Write("There's no Active task with the Priority ID: {0} and the Category name: {1}", _options.Priority, _options.CategoryName);
                }
                else if (_options.Priority != 0)
                {
                    Write("There's no Active task with the Priority ID: {0}", _options.Priority);
                }
                else if (!string.IsNullOrWhiteSpace(_options.CategoryName))
                {
                    Write("There's no Active task with the Category name: {0}", _options.CategoryName);
                }
                else
                {
                    Write("There's no Active task");
                }
            }

            for (var i = 0; i < activeTasks.Count; i++)
            {
                var task = activeTasks[i];

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