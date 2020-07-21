using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using TaskCore.App.Options;
using TaskCore.App.Views;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.App.Verbs
{
    [VerbName("rmc", Description = "Removes a given category.")]
    public class RemoveCategory : VerbBase<RemoveCategoryOptions>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITodoTaskRepository _todoTaskRepository;

        public RemoveCategory(ICategoryRepository categoryRepository,
            ITodoTaskRepository todoTaskRepository)
        {
            _categoryRepository = categoryRepository;
            _todoTaskRepository = todoTaskRepository;
        }

        public override VerbViewBase Run()
        {
            if (Options.CategoryName.ToLower() != "inbox")
            {
                _categoryRepository.DeleteByName(Options.CategoryName);
                var activeTasks = _todoTaskRepository.GetActiveTasksByCategoryName(new Category()
                {
                    Name = Options.CategoryName
                });
                foreach (var task in activeTasks)
                {
                    _todoTaskRepository.Delete(task);
                }
            }

            return new RemoveCategoryView(Options);
        }
    }
}