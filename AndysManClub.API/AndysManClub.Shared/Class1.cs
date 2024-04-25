namespace AndysManClub.Shared;

public interface IAmcClient
{
}

public class AmcClient(HttpClient httpClient) : IAmcClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    
    
}