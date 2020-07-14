using System.Collections.Generic;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.FileSystem
{
    public class TodoTaskRepository: ITodoTaskRepository
    {
        public TodoTask Get(string taskId)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<TodoTask> GetByCategory(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void Add(TodoTask task)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string taskId)
        {
            throw new System.NotImplementedException();
        }
    }
}