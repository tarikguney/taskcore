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

        public IReadOnlyList<TodoTask> GetActiveTasksOrderedByAddedDate(bool includeCompletedTasks = false)
        {
            var activeTasks = _fileManager.GetActiveTasksContents();
            return activeTasks
                .Select(a => JsonSerializer.Create()
                    .Deserialize<TodoTask>(new JsonTextReader(new StringReader(a))))
                .OrderByDescending(a => a.Id)
                .ToList();
        }

        public IReadOnlyList<TodoTask> GetCompletedTasksOrderedByAddedDate(bool includeCompletedTasks = false)
        {
            var activeTasks = _fileManager.GetCompletedTasksContents();
            return activeTasks
                .Select(a => JsonSerializer.Create()
                    .Deserialize<TodoTask>(new JsonTextReader(new StringReader(a))))
                .OrderByDescending(a => a.Id)
                .ToList();
        }

        public void Update(TodoTask task)
        {
            if (task.Completed)
            {
                _fileManager.SaveCompletedTask(task.Id.ToString(),
                    JObject.FromObject(task).ToString());
            }
            else
            {
                _fileManager.SaveActiveTask(task.Id.ToString(),
                    JObject.FromObject(task).ToString());
            }
        }

        public void MarkComplete(TodoTask task)
        {
            task.Completed = true;
            task.CompletionDate = DateTimeOffset.Now;
            _fileManager.DeleteActiveTask(task.Id.ToString());
            _fileManager.SaveCompletedTask(task.Id.ToString(), JObject.FromObject(task).ToString());
        }

        public IReadOnlyList<TodoTask> GetActiveTasksByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Add(TodoTask task)
        {
            var jTask = JObject.FromObject(task);
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            jTask["Id"] = timestamp;
            _fileManager.SaveActiveTask(timestamp.ToString(), jTask.ToString());
        }

        public void Delete(TodoTask task)
        {
            if (task.Completed)
            {
                _fileManager.DeleteCompletedTask(task.Id.ToString());
            }
            else
            {
                _fileManager.DeleteActiveTask(task.Id.ToString());
            }
        }
    }
}