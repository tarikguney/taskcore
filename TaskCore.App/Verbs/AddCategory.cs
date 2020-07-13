using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Verbs
{
    [VerbName("addc")]
    public class AddCategory: VerbBase<AddCategoryOptions>
    {
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}