[![NuGet version (WallHavenClient)](https://img.shields.io/nuget/v/WallHavenClient.svg?style=flat-square)](https://www.nuget.org/packages/WallHavenClient/)
[![Nuget](https://img.shields.io/nuget/dt/WallHavenClient?logo=nuget&style=flat-square)](https://www.nuget.org/packages/WallHavenClient/)
[![.NET](https://github.com/Bigtalljosh/WallHavenClient/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Bigtalljosh/WallHavenClient/actions/workflows/dotnet.yml)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/Bigtalljosh/WallHavenClient/blob/main/LICENSE)

# WallHavenClient

WallHavenClient is a simple wrapped around the [WallHaven](https://wallhaven.cc/) API.
There's a fluent query builder to simplify getting you the wallpapers you want.

I've wrote this as a very quick thing to run in a background app to keep my desktop wallpaper updating on an interval.



## Getting Started

Install Nuget Package into test project:

```cmd
dotnet add package WallHavenClient
```

Then once the package is installed you need to add the using statements

```csharp
using WallHavenClient;
```

And from here you simply add the following to your DI

```csharp
services.AddHttpClient<IWallHavenClient, WallHavenClient>();
```

And add some app settings:

```json
  "WallHaven": {
    "APIKey": "", // Optional - Only used on NSFW Requests
    "BaseUrl": "https://wallhaven.cc/api/v1/"
  }
```

And bind this to the configuration object, and add that as a Singleton.
Or however you want to get config, there's a few ways now.

```csharp
Config config = new();
hostContext.Configuration.GetSection("WallHaven").Bind(config);
services.AddSingleton(config);
```

## Contributions

Currently in a very early version/stage of this project.
Open to PRs and critique, it's not the cleanest code but it does the job.
Please raise issues and feel free to submit PRs (happy to discuss in an issue first to avoid wasted effort).

## Examples

Todo...
