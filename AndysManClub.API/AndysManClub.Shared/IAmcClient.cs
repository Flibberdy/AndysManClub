using AndysManClub.Domain.DTO;

namespace AndysManClub.Shared;

public interface IAmcClient
{
    Task<ApiResponse<AmcEvent>> CreateEvent(AmcEvent amcEvent);
}