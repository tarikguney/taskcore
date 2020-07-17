using System;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Views
{
    public class AddTaskView: VerbViewBase
    {
        private readonly AddTaskOptions _options;

        public AddTaskView(AddTaskOptions options)
        {
            _options = options;
        }
        
        public override void RenderResponse()
        {
            // TODO Need to display a better message here.
            Console.WriteLine("Task has been added!");
        }
    }
}