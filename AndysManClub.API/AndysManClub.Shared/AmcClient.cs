using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AndysManClub.Domain.DTO;

namespace AndysManClub.Shared;

public class AmcClient : IAmcClient
{
    private readonly HttpClient _httpClient;

    public AmcClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<ApiResponse<AmcEvent>> CreateEvent(AmcEvent amcEvent)
    {
        var content = new StringContent(JsonSerializer.Serialize(amcEvent), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("Event", content);

        if (response.IsSuccessStatusCode)
        {
            return new ApiResponse<AmcEvent>
            {
                Success = true,
                Data = amcEvent
            };
        }

        return new ApiResponse<AmcEvent>
        {
            Success = false,
            Errors = [response.ReasonPhrase ?? "Unknown error"]
        };
    }
}