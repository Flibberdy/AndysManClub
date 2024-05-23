using AndysManClub.Domain.AggregateRoot;
using AndysManClub.Shared.Dto;

namespace AndysManClub.Shared;

public interface IAmcClient
{
    Task<ApiResponse<List<string>>> CreateEvent(CreateAmcEventDto amcEvent);
}