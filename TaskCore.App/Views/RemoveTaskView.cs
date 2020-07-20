using System;
using CommandCore.Library.PublicBase;
using TaskCore.Dal.Models;

namespace TaskCore.App.Views
{
    public class RemoveTaskView: VerbViewBase
    {
        private readonly TodoTask _task;

        public RemoveTaskView(TodoTask task)
        {
            _task = task;
        }
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Deleted task \"{_task.Title}\"");
            Console.ResetColor();
        }
    }
}