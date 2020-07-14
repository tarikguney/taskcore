using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Verbs
{
    [VerbName("c")]
    public class CompleteTask: VerbBase<CompleteTaskOptions>
    {
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}