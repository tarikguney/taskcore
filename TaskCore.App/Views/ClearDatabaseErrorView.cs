using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Views
{
    public class ClearDatabaseErrorView: VerbViewBase
    {
        private readonly ClearDatabaseOptions _options;

        public ClearDatabaseErrorView(ClearDatabaseOptions options)
        {
            _options = options;
        }
        
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "If you're sure you want to delete the database folder, rerun this command with --force.");
            Console.ResetColor();
            Environment.ExitCode = 105;
        }
    }
}
