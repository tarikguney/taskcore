using System;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Views
{
    public class AddTaskRequiredFieldsMissingView: VerbViewBase
    {
        public override void RenderResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Task title is required. Please enter one to create a new task item.");
            Console.ResetColor();
        }
    }
}