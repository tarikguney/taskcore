using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Verbs
{
    [VerbName("rmc")]
    public class RemoveCategory: VerbBase<RemoveCategoryOptions>
    {
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}