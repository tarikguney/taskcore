using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using static System.Console;

namespace TaskCore.App.Views
{
    public class AddTaskView: VerbViewBase
    {
        private readonly AddTaskOptions _options;

        public AddTaskView(AddTaskOptions options)
        {
            _options = options;
        }
        
        public override void RenderResponse()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Added the task \"{_options.Title}\"");
            ResetColor();
        }
    }
}