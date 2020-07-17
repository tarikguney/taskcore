using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaskCore.Dal.Interfaces;
using TaskCore.Dal.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TaskCore.Dal.FileSystem
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly FileManager _fileManager;

        public TodoTaskRepository()
        {
            _fileManager = new FileManager();
        }

        public TodoTask Get(string taskId)
        {
            var content = _fileManager.ReadTaskFileContent(taskId);
            return JsonSerializer.Create().Deserialize<TodoTask>(new JsonTextReader(new StringReader(content)));
        }

        public IReadOnlyList<TodoTask> GetAll()
        {
            var allFiles = _fileManager.GetAllTaskFilesContent();
            return allFiles
                .Select(a => JsonSerializer.Create()
                    .Deserialize<TodoTask>(new JsonTextReader(new StringReader(a))))
                .OrderBy(a => a.Id)
                .ToList();
        }

        public IReadOnlyList<TodoTask> GetByCategory(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void Add(TodoTask task)
        {
            var jTask = JObject.FromObject(task);
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var fileName = timestamp.ToString();
            jTask["Id"] = timestamp;
            _fileManager.SaveTaskFile(fileName, jTask.ToString());
        }

        public bool Delete(string taskId)
        {
            //var content = _fileManager.ReadTaskFileContent(taskId);
            return true;
        }
    }
}