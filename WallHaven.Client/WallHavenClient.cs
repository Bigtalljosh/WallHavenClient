using System.Text.Json;

namespace WallHaven.Client
{
    public class WallHavenClient : IWallHavenClient
    {
        private readonly HttpClient _client;

        public WallHavenClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<WallHavenResponse> GetWallpaper(string id)
        {
            var response = await _client.GetAsync($"{id}");
            var responseJson = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<WallHavenResponse>(responseJson) : null;
        }

        public async Task<WallHavenResponse> Search(string searchParams)
        {
            var response = await _client.GetAsync($"search/{searchParams}");
            var responseJson = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<WallHavenResponse>(responseJson) : null;
        }
    }
}