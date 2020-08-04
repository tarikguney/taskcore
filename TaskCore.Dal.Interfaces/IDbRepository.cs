namespace TaskCore.Dal.Interfaces
{
    public interface IDbRepository
    {
        void Clear();
        void Open();
        string Show();
    }
}
