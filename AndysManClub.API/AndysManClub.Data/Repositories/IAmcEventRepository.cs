using AndysManClub.Data.Models;

namespace AndysManClub.Data.Repositories
{
    public interface IAmcEventRepository
    {
        void Create(AmcEvent amcEvent);
        IEnumerable<AmcEvent> Get();
        AmcEvent Get(Guid id);
        Task Save();
    }
}
