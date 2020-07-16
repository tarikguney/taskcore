using System.IO;

namespace TaskCore.Dal.FileSystem
{
    internal class TaskPathProvider
    {
        public DirectoryInfo GetDir()
        {
            if (!Directory.Exists("./tasks"))
            {
                Directory.CreateDirectory("./tasks");
            }
            return new DirectoryInfo("./tasks");
        }
    }
}