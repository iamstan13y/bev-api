namespace BevAPI.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPlayerRepository Player { get; }
        IDrillRepository Drill { get; }
        IPlayerDrillRepository PlayerDrill { get; }

        void SaveChanges();
    }
}