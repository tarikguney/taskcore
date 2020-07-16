using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.Dal.Interfaces;

namespace TaskCore.App.Verbs
{
    [VerbName("addc")]
    public class AddCategory: VerbBase<AddCategoryOptions>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public override VerbViewBase Run()
        {
            throw new System.NotImplementedException();
        }
    }
}