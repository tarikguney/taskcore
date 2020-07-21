using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.FileSystem
{
    public class CategoryRepository : ICategoryRepository
    {
        private FileManager _fileManager;

        public CategoryRepository()
        {
            _fileManager = new FileManager();
        }

        public Category GetByName(string categoryName)
        {
            var content = _fileManager.GetCategory(new Category() {Name = categoryName}.CategoryId);
            return content == null
                ? null
                : new JsonSerializer().Deserialize<Category>(new JsonTextReader(new StringReader(content)));
        }

        public Category Add(Category category)
        {
            var content = JObject.FromObject(category);
            _fileManager.SaveCategory(category.CategoryId, content.ToString());
            return category;
        }

        public bool DeleteByName(string categoryName)
        {
            _fileManager.DeleteCategory(new Category() {Name = categoryName}.CategoryId);
            return true;
        }
    }
}