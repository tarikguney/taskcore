using System;
using System.Collections.Generic;
using CommandCore.Library.PublicBase;
using TaskCore.Dal.Models;

namespace TaskCore.App.Views
{
    public class RemoveTaskView: VerbViewBase
    {
        private readonly List<TodoTask> _tasks;

        public RemoveTaskView(List<TodoTask> tasks)
        {
            _tasks = tasks;
        }
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var task in _tasks)
            {
                Console.WriteLine($"Deleted task \"{task.Title}\"");
            }
            Console.ResetColor();
        }
    }
}