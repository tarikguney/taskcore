using TaskCore.Dal.Interfaces;

namespace TaskCore.Dal.FileSystem
{
    public class DbRepository : IDbRepository
    {
        private readonly FileManager _fileManager;
        public DbRepository()
        {
            _fileManager = new FileManager();
        }
        public string GetPath()
        {
            return _fileManager.GetDbPath();
        }
        public void Open()
        {
            _fileManager.OpenDbFolder();
        }
        public void Clear()
        {
            _fileManager.RemoveDbFolder();
        }
    }
}
