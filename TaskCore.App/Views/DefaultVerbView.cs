using System;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Views
{
    public class DefaultVerbView: VerbViewBase
    {
        public override void RenderResponse()
        {
            Console.WriteLine("Please use --help to find out which commands are available.");
        }
    }
}