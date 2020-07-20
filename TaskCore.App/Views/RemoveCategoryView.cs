using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Views
{
    public class RemoveCategoryView : VerbViewBase
    {
        private readonly RemoveCategoryOptions _options;

        public RemoveCategoryView(RemoveCategoryOptions options)
        {
            _options = options;
        }

        public override void RenderResponse()
        {
            if (_options.CategoryName.ToLower() == "inbox")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Inbox category may not be deleted as it is the default category that always exists!");
                Console.ResetColor();;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Deleted category \"{_options.CategoryName}\"");
            Console.ResetColor();
        }
    }
}