namespace BevAPI.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPlayerRepository Player { get; }
        IDrillRepository Drill { get; }

        void SaveChanges();
    }
}