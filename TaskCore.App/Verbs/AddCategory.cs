using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.App.Verbs
{
    [VerbName("addc", Description = "Adds new category.")]
    public class AddCategory : VerbBase<AddCategoryOptions>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override VerbViewBase Run()
        {
            if (_categoryRepository.GetByName(Options.Title) != null)
            {
                return new AddCategoryErrorView(Options);
            }
            
            _categoryRepository.Add(new Category()
            {
                Name = Options.Title
            });
            
            return new AddCategoryView(Options);
        }
    }
}