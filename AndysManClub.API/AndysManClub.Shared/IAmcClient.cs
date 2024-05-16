using AndysManClub.Domain.AggregateRoot;

namespace AndysManClub.Shared;

public interface IAmcClient
{
    Task<ApiResponse<AmcEvent>> CreateEvent(AmcEvent amcEvent);
}