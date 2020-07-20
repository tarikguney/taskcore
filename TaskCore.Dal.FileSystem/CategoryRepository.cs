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
            var content = _fileManager.GetCategory(GenerateCategoryId(categoryName));
            return content == null
                ? null
                : new JsonSerializer().Deserialize<Category>(new JsonTextReader(new StringReader(content)));
        }

        public Category Add(Category category)
        {
            category.CategoryId = GenerateCategoryId(category.Name);
            var content = JObject.FromObject(category);
            _fileManager.SaveCategory(category.CategoryId, content.ToString());
            return category;
        }

        public bool DeleteByName(string categoryName)
        {
            // TODO removing a category should mean something other than simply deleting the category name.
            // Perhaps it means to delete all of the active tasks under the category.
            _fileManager.DeleteCategory(GenerateCategoryId(categoryName));
            return true;
        }

        private static string GenerateCategoryId(string categoryName)
        {
            return GenerateHash(categoryName.ToLower()).ToString();
        }

        private static int GenerateHash(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}