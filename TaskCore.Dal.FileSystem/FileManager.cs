using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskCore.Dal.FileSystem
{
    internal class FileManager
    {
        string DB_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "taskcore");

        private readonly DirectoryInfo _activeTasksDir;
        private readonly DirectoryInfo _completedTasksDir;
        private readonly DirectoryInfo _categoriesDir;

        public FileManager()
        {
            if (!Directory.Exists(DB_PATH))
            {
                Directory.CreateDirectory(DB_PATH);
                Directory.CreateDirectory(Path.Combine(DB_PATH, "active"));
                Directory.CreateDirectory(Path.Combine(DB_PATH, "completed"));
                Directory.CreateDirectory(Path.Combine(DB_PATH, "categories"));
            }

            _activeTasksDir = new DirectoryInfo(Path.Combine(DB_PATH, "active"));
            _completedTasksDir = new DirectoryInfo(Path.Combine(DB_PATH, "completed"));
            _categoriesDir = new DirectoryInfo(Path.Combine(DB_PATH, "categories"));
        }

        public void SaveActiveTask(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_activeTasksDir.FullName, fileName),
                content);
        }

        public void SaveCompletedTask(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_completedTasksDir.FullName, fileName),
                content);
        }

        public void DeleteActiveTask(string fileName)
        {
            File.Delete(Path.Combine(_activeTasksDir.FullName, fileName));
        }

        public void DeleteCompletedTask(string fileName)
        {
            File.Delete(Path.Combine(_completedTasksDir.FullName, fileName));
        }

        public List<string> GetActiveTasksContents()
        {
            var allTaskFiles = _activeTasksDir.GetFiles();
            return allTaskFiles.Select(a => File.ReadAllText(a.FullName)).ToList();
        }

        public List<string> GetCompletedTasksContents()
        {
            var allTaskFiles = _completedTasksDir.GetFiles();
            return allTaskFiles.Select(a => File.ReadAllText(a.FullName)).ToList();
        }

        public void SaveCategoryFile(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_categoriesDir.FullName, fileName), content);
        }

        public void DeleteCategoryFile(string fileName)
        {
            var fileAbsolutePath = Path.Combine(_categoriesDir.FullName, fileName);
            if (File.Exists(fileAbsolutePath))
            {
                File.Delete(fileAbsolutePath);
            }
        }

        public string? GetCategoryFile(string fileName)
        {
            var fileAbsolutePath = Path.Combine(_categoriesDir.FullName, fileName);
            return File.Exists(fileAbsolutePath) ? File.ReadAllText(fileAbsolutePath) : null;
        }

        public List<string> GetAlCategoryFiles()
        {
            var files = _categoriesDir.GetFiles();
            return files.Select(a => File.ReadAllText(a.FullName)).ToList();
        }
    }
}