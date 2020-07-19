using System;
using System.Drawing;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Views
{
    public class AddCategoryView : VerbViewBase
    {
        private readonly AddCategoryOptions _options;

        public AddCategoryView(AddCategoryOptions options)
        {
            _options = options;
        }

        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Added category \"{_options.Title}\"");
            Console.ResetColor();
        }
    }
}