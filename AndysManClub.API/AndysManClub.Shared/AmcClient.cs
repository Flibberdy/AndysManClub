using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AndysManClub.Domain.AggregateRoot;
using AndysManClub.Shared.Dto;

namespace AndysManClub.Shared;

public class AmcClient : IAmcClient
{
    private readonly HttpClient _httpClient;

    public AmcClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<ApiResponse<List<string>>> CreateEvent(CreateAmcEventDto amcEvent)
    {
        var content = new StringContent(JsonSerializer.Serialize(amcEvent), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("Event", content);

        if (!response.IsSuccessStatusCode)
        {
            return new ApiResponse<List<string>>
            {
                Success = false,
                Errors = [response.ReasonPhrase ?? "Unknown error"]
            };
        }

        return new ApiResponse<List<string>>()
        {
            Success = true,
            Data = new List<string>()
        };
    }

    public async Task<ApiResponse<List<ViewAmcEventSummaryDto>>> GetEvents()
    {
        return new ApiResponse<List<ViewAmcEventSummaryDto>>
        {
            Success = true,
            Data = new List<ViewAmcEventSummaryDto>()
            {
                new ViewAmcEventSummaryDto()
                {
                    Title = "The best title",
                    Location = "Another Location",
                    Description = "The best description"
                },
                new ViewAmcEventSummaryDto()
                {
                    Title = "The second best title",
                    Location = "A different Location",
                    Description = "The second best description"
                }
            }
        };
    }
}