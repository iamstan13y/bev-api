namespace BevAPI.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPlayerRepository Player { get; }
        void SaveChanges();
    }
}