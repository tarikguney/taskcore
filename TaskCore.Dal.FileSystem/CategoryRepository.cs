using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.FileSystem
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FileManager _fileManager;

        public CategoryRepository()
        {
            _fileManager = new FileManager();
        }

        public Category? GetByName(string categoryName)
        {
            if (categoryName.ToLower() == "inbox")
            {
                return new Category() {Name = "Inbox"};
            }

            var content = _fileManager.GetCategoryFile(new Category() {Name = categoryName}.CategoryId);
            return content == null
                ? null
                : new JsonSerializer().Deserialize<Category>(new JsonTextReader(new StringReader(content)));
        }

        public Category Add(Category category)
        {
            var content = JObject.FromObject(category);
            _fileManager.SaveCategoryFile(category.CategoryId, content.ToString());
            return category;
        }

        public bool DeleteByName(string categoryName)
        {
            _fileManager.DeleteCategoryFile(new Category() {Name = categoryName}.CategoryId);
            return true;
        }

        public IReadOnlyList<Category> GetAllCategories()
        {
            List<string> categoryFiles = _fileManager.GetAlCategoryFiles();
            var categories = categoryFiles.Select(a =>
                new JsonSerializer()
                    .Deserialize<Category>(new JsonTextReader(new StringReader(a)))).ToList();
            categories.Add(new Category() {Name = "Inbox"});
            return categories;
        }
    }
}