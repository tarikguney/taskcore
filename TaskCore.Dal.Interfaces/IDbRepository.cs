namespace TaskCore.Dal.Interfaces
{
    public interface IDbRepository
    {
        string GetPath();
        void Clear();
        void Open();
    }
}
