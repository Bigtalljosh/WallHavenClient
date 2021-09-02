using System.Text.Json;

namespace WallHavenClient
{
    public class WallHavenClient : IWallHavenClient
    {
        private readonly HttpClient _client;

        public WallHavenClient(HttpClient client, Config config)
        {
            _client = client;
            _client.BaseAddress = new Uri(config.BaseUrl);

            if (config.APIKey is not null)
            {
                _client.DefaultRequestHeaders.Add("X-API-Key", config.APIKey);
            }
        }

        public async Task<WallHavenResponse> GetWallpaper(string wallpaperId)
        {
            var response = await _client.GetAsync($"w/{wallpaperId}").ConfigureAwait(false);
            var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseObject = response.IsSuccessStatusCode ? JsonSerializer.Deserialize<WallHavenResponse>(responseJson) : null;

            if (responseObject is not null)
                return responseObject;
            else
                throw new NotFoundException($"Wallpaper ID: {wallpaperId}");
        }

        public async Task<WallHavenResponse> Search(string searchParams)
        {
            var response = await _client.GetAsync($"search/{searchParams}");
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObject = response.IsSuccessStatusCode ? JsonSerializer.Deserialize<WallHavenResponse>(responseJson) : null;

            if (responseObject is not null)
                return responseObject;
            else
                throw new DeserializeException($"Search Params Used: {searchParams}");
        }
    }
}