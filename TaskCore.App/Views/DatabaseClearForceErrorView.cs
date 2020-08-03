using CommandCore.Library.PublicBase;
using System;
namespace TaskCore.App.Views
{
    public class DatabaseClearForceErrorView : VerbViewBase
    {
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("If you're sure you want to remove the database folder, rerun this command with --force.");
            Console.ResetColor();
            Environment.ExitCode = 105;
        }
    }
}
