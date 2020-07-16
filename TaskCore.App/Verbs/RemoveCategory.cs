using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("rmc", Description = "Removes a given task.")]
    public class RemoveCategory : VerbBase<RemoveCategoryOptions>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}