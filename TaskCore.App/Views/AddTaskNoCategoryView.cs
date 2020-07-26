using System;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Views
{
    public class AddTaskNoCategoryView : VerbViewBase
    {
        private readonly string _categoryName;

        public AddTaskNoCategoryView(string categoryName)
        {
            _categoryName = categoryName;
        }

        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"Cannot find category named {_categoryName}. Either add it first or leave it empty so that default category \"Inbox\" can be used");
            Console.ResetColor();
            Environment.ExitCode = 100;
        }
    }
}