using AndysManClub.Domain.AggregateRoot;
using AndysManClub.Shared.Dto;

namespace AndysManClub.Domain.Repositories
{
    public interface IAmcEventRepository
    {
        void Create(AmcEvent amcEvent);
        List<ViewAmcEventSummaryDto> Get();
        AmcEvent? Get(Guid id);
        Task Save();
    }
}
