using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Views
{
    public class ClearDatabaseView : VerbViewBase
    {
        private readonly ClearDatabaseOptions _options;

        public ClearDatabaseView(ClearDatabaseOptions options)
        {
            _options = options;
        }

        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Database folder removed.");
            Console.ResetColor();
        }
    }
}
