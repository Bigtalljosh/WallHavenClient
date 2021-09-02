using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WallHaven.Client;

namespace Haven.Core
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IWallHavenClient _wallHavenClient;
        private readonly string _searchParams;


        public Worker(ILogger<Worker> logger, IWallHavenClient wallHavenClient)
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

            _logger = logger;
            _wallHavenClient = wallHavenClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var result = await _wallHavenClient.Search(_searchParams);

            _logger.LogInformation($"Number of results: {result.Data.Count}");

            foreach (var wallpaper in result.Data)
            {
                _logger.LogInformation($"{wallpaper.Url}");
            }
        }
    }
}
