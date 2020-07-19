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

        public TodoTask Get(long taskId)
        {
            var content = _fileManager.ReadTaskFileContent(taskId.ToString());
            return JsonSerializer.Create().Deserialize<TodoTask>(new JsonTextReader(new StringReader(content)));
        }

        public IReadOnlyList<TodoTask> GetAll(bool includeCompletedTasks = false)
        {
            var fileNames = GetTasksSortedByIdDesc(includeCompletedTasks);
            // TODO each file needs to know if it comes from completed or active folders.
            //fileNames.Select(a=> _fileManager.)
            
            var allFiles = _fileManager.GetAllTaskFilesContent();
            return allFiles
                .Select(a => JsonSerializer.Create()
                    .Deserialize<TodoTask>(new JsonTextReader(new StringReader(a))))
                .OrderByDescending(a => a.Id)
                .ToList();
        }

        public IReadOnlyList<long> GetTasksSortedByIdDesc(bool includeCompletedTasks = false)
        {
            var activeTaskIds = _fileManager.GetAllActiveTasksFileNames()
                .OrderByDescending(a => a).ToList();
            if (includeCompletedTasks)
            {
                var completedTaskIds = _fileManager.GetAllCompletedTaskFileNames()
                    .OrderByDescending(a => a).ToList();
                activeTaskIds.Concat(completedTaskIds);
            }

            return activeTaskIds;
        }

        public void Update(TodoTask task)
        {
            _fileManager.SaveTaskFile(task.Id.ToString(), JObject.FromObject(task).ToString());
        }

        public IReadOnlyList<TodoTask> GetByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public void Add(TodoTask task)
        {
            var jTask = JObject.FromObject(task);
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            jTask["Id"] = timestamp;
            _fileManager.SaveTaskFile(timestamp.ToString(), jTask.ToString());
        }

        public bool Delete(string taskId)
        {
            //var content = _fileManager.ReadTaskFileContent(taskId);
            return true;
        }
    }
}