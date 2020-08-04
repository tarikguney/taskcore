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
        
        public void Clear()
        {
            _fileManager.RemoveDbFolder();    
        }
        public void Open()
        {
            _fileManager.OpenDbPath();
        }
        public string Show()
        {
           return _fileManager.ShowDbPath();
        }
    }
}
