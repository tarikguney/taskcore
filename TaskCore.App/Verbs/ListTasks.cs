using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;

namespace TaskCore.App.Verbs
{
    [VerbName("list")]
    public class ListTasks: VerbBase<ListTasksOptions>
    {
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}