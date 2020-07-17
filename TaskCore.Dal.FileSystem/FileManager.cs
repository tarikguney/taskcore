using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskCore.Dal.FileSystem
{
    internal class FileManager
    {
        private readonly DirectoryInfo _dir;
        
        public FileManager()
        {
            if (!Directory.Exists("./tasks"))
            {
                Directory.CreateDirectory("./tasks");
            }
            _dir = new DirectoryInfo("./tasks");
        }

        public void SaveTaskFile(string taskId, string content)
        {
            File.WriteAllText(Path.Combine(_dir.FullName, taskId), content);
        }

        public string ReadTaskFileContent(string taskId)
        {
            return File.ReadAllText(Path.Combine(_dir.FullName, taskId));
        }

        public List<string> GetAllTaskFilesContent()
        {
            var allTaskFiles = _dir.GetFiles();
            return allTaskFiles.Select(a => File.ReadAllText(a.FullName)).ToList();
        }

        public List<long> GetAllFileNames()
        {
            // TODO this is still inefficient, I am thinking to keep some information as part of the file name to avoid file content parsing
            // TODO Perhaps choose only the open tasks and ask for a specific flag to get the completed tasks too.
            return _dir.GetFiles().Select(a => long.Parse(a.Name)).ToList();
        }
    }
}