using System;
using CommandCore.Library.PublicBase;
using TaskCore.Dal.Models;

namespace TaskCore.App.Views
{
    public class CompleteTaskView: VerbViewBase
    {
        private readonly TodoTask _task;

        public CompleteTaskView(TodoTask task)
        {
            _task = task;
        }
        public override void RenderResponse()
        {
            Console.WriteLine($"Completed the task \"{_task.Title}\"");
        }
    }
}