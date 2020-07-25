using System;
using System.Collections.Generic;
using CommandCore.Library.PublicBase;
using TaskCore.Dal.Models;

namespace TaskCore.App.Views
{
    public class CompleteTaskView : VerbViewBase
    {
        private readonly List<TodoTask> _tasks;

        public CompleteTaskView(List<TodoTask> tasks)
        {
            _tasks = tasks;
        }

        public override void RenderResponse()
        {
            foreach (var task in _tasks)
            {
                Console.WriteLine($"Completed the task \"{task.Title}\"");
            }
        }
    }
}