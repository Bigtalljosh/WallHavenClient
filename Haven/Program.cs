using Haven.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WallHavenClient;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();

        Config config = new();
        hostContext.Configuration.GetSection("WallHaven").Bind(config);
        services.AddSingleton(config);
        services.AddHttpClient<IWallHavenClient, WallHavenClient.WallHavenClient>(client =>
        {
            client.BaseAddress = new Uri(config.BaseUrl);
        });
    })
    .Build();

await host.RunAsync();