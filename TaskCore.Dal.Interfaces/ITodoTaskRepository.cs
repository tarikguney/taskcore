using System.Collections.Generic;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.Interfaces
{
    public interface ITodoTaskRepository
    {
        IReadOnlyList<TodoTask> GetActiveTasksOrderedByAddedDate(bool includeCompletedTasks = false);
        IReadOnlyList<TodoTask> GetCompletedTasksOrderedByAddedDate(bool includeCompletedTasks = false);
        void Update(TodoTask task);
        IReadOnlyList<TodoTask> GetByCategory(string categoryId);
        void Add(TodoTask task);
        void Delete(TodoTask task);
        void MarkComplete(TodoTask task);
    }
}