using CommandCore.Library.PublicBase;
using System;
namespace TaskCore.App.Views
{
    class DatabaseMultiCommandUsageErrorView : VerbViewBase
    {
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You could not use any other database commands with the Clear command.");
            Console.ResetColor();
        }
    }
}
