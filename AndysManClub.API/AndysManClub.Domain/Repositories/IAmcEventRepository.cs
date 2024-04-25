using AndysManClub.Domain.DTO;

namespace AndysManClub.Domain.Repositories
{
    public interface IAmcEventRepository
    {
        void Create(AmcEvent amcEvent);
        IEnumerable<AmcEvent?> Get();
        AmcEvent? Get(Guid id);
        Task Save();
    }
}
