using TaskCore.Dal.Models;

namespace TaskCore.Dal.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(string categoryId);

        /// <summary>
        /// Creates a new category and returns a category object with Id. 
        /// </summary>
        Category Add(Category category);

        /// <summary>
        /// Deletes a category and returns true if the deletion was a success.
        /// </summary>
        bool Delete(string categoryId);
    }
}