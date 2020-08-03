using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string dbPath = GetDbPath();
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
                Directory.CreateDirectory(Path.Combine(dbPath, "active"));
                Directory.CreateDirectory(Path.Combine(dbPath, "completed"));
                Directory.CreateDirectory(Path.Combine(dbPath, "categories"));
            }

            _activeTasksDir = new DirectoryInfo(Path.Combine(dbPath, "active"));
            _completedTasksDir = new DirectoryInfo(Path.Combine(dbPath, "completed"));
            _categoriesDir = new DirectoryInfo(Path.Combine(dbPath, "categories"));
        }

        public string GetDbPath()
        {
            string dbPath = Environment.GetEnvironmentVariable("TASKCORE_DB_PATH") ?? string.Empty;
            return string.IsNullOrWhiteSpace(dbPath)
                ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "taskcore")
                : dbPath;
        }

        public void OpenDbFolder()
        {
            try
            {
                if (GetDbPath().Contains("AppData")) // windows
                {
                    Process.Start("explorer", GetDbPath());
                }
                else if(false) // mac
                {

                }
                else //unix, linux systems which are using 'nautilus' file manager
                {
                    Process.Start("nautilus", GetDbPath());
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Could not reach your file manager to open database folder, you could use 'database -s' command to see your database path");
                Console.ResetColor();
            }
        }

        public void RemoveDbFolder()
        {
            Directory.Delete(GetDbPath(), true);
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