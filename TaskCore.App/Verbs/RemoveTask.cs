using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Verbs
{
    [VerbName("rm")]
    public class RemoveTask: VerbBase<RemoveTaskOptions>
    {
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}