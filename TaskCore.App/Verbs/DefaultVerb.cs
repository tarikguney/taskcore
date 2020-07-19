using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;

namespace TaskCore.App.Verbs
{
    [VerbName("default", Description = "Default ")]
    public class DefaultVerb: VerbBase<DefaultOptions>
    {
        public override VerbViewBase Run()
        {
            return new DefaultVerbView();
        }
    }
}