using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Views
{
    public class AddCategoryErrorView: VerbViewBase
    {
        private readonly AddCategoryOptions _options;

        public AddCategoryErrorView(AddCategoryOptions options)
        {
            _options = options;
        }
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"Category \"{_options.Title}\" already exists. Please use a different category name. Remember, the category names are not case sensitive.");
            Console.ResetColor();
        }
    }
}