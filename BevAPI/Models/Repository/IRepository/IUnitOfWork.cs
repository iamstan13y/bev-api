namespace BevAPI.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}