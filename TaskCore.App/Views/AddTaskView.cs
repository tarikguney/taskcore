using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Models;
using static System.Console;

namespace TaskCore.App.Views
{
    public class AddTaskView : VerbViewBase
    {
        private readonly AddTaskOptions _options;
        private readonly Category _category;

        public AddTaskView(AddTaskOptions options, Category category)
        {
            _options = options;
            _category = category;
        }

        public override void RenderResponse()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Added the task \"{_options.Title}\" to {_category.Name}");
            ResetColor();
        }
    }
}