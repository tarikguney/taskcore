using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.FileSystem
{
    public class TodoTaskRepository: ITodoTaskRepository
    {
        private DirectoryInfo _dir;

        public TodoTaskRepository()
        {
            _dir = new TaskPathProvider().GetDir();
        }
        
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
            var jTask = JObject.FromObject(task);
            var fileName = jTask.GetHashCode().ToString();
            jTask["Id"] = fileName;
            File.WriteAllText(Path.Combine(_dir.FullName, fileName), jTask.ToString());
        }

        public bool Delete(string taskId)
        {
            throw new System.NotImplementedException();
        }
    }
}