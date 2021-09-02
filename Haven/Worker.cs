using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WallHavenClient;

namespace Haven.Runner
{
    public class Worker : BackgroundService
    {
        private readonly IWallHavenClient _wallHavenClient;
        private readonly string _searchParams;
        private readonly ILogger _logger;

        public Worker(IWallHavenClient wallHavenClient, ILogger<Worker> logger)
        {
            _searchParams = new SearchParamsBuilder()
                .WithMinimumResolution(3440, 1440)
                .IncludeGeneral(true)
                .IncludeAnime(false)
                .IncludePeople(false)
                .IncludeSafe(true)
                .IncludeSketchy(false)
                .IncludeNSFW(false)
                .OrderBy(OrderBy.desc)
                .SortBy(Sorting.date_added)
                .Build();

            _wallHavenClient = wallHavenClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var result = await _wallHavenClient.Search(_searchParams);
            _logger.LogInformation($"Number of results: {result.Data.Count}");

            foreach (var wallpaper in result.Data)
                _logger.LogInformation($"{wallpaper.Url}");
        }
    }
}
