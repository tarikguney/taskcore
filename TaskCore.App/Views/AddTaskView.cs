using System;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Views
{
    public class AddTaskView: VerbViewBase
    {
        private readonly string _message;

        public AddTaskView(string message)
        {
            _message = message;
        }
        
        public override void RenderResponse()
        {
            Console.WriteLine(_message);
        }
    }
}