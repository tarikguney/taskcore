using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskCore.Dal.FileSystem
{
    internal class FileManager
    {
        private readonly DirectoryInfo _activeTasksDir;
        private readonly DirectoryInfo _completedTasksDir;
        private readonly DirectoryInfo _categoriesDir;

        public FileManager()
        {
            if (!Directory.Exists("./db/active"))
            {
                Directory.CreateDirectory("./db/active");
            }

            _activeTasksDir = new DirectoryInfo("./tasks/active");

            if (!Directory.Exists("./db/completed"))
            {
                Directory.CreateDirectory("./db/completed");
            }

            _completedTasksDir = new DirectoryInfo("./tasks/completed");

            if (!Directory.Exists("./db/categories"))
            {
                Directory.CreateDirectory("./tasks/categories");
            }

            _categoriesDir = new DirectoryInfo("./tasks/categories");
        }

        public void SaveTaskFile(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_activeTasksDir.FullName, fileName),
                content);
        }

        public string ReadTaskFileContent(string taskId)
        {
            return File.ReadAllText(Path.Combine(_activeTasksDir.FullName, taskId));
        }

        public List<string> GetAllTaskFilesContent()
        {
            var allTaskFiles = _activeTasksDir.GetFiles();
            return allTaskFiles.Select(a => File.ReadAllText(a.FullName)).ToList();
        }

        public List<long> GetAllActiveTasksFileNames()
        {
            return _activeTasksDir.GetFiles()
                .Select(a => long.Parse(a.Name)).ToList();
        }

        public List<long> GetAllCompletedTaskFileNames()
        {
            return _completedTasksDir.GetFiles()
                .Select(a => long.Parse(a.Name)).ToList();
        }

        public List<string> GetAllCategoryFileNames()
        {
            return _categoriesDir.GetFiles()
                .Select(a => a.Name).ToList();
        }
    }
}