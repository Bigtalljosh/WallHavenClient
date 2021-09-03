[![NuGet version (WallHavenClient)](https://img.shields.io/nuget/v/WallHavenClient.svg?style=flat-square)](https://www.nuget.org/packages/WallHavenClient/)
[![Nuget](https://img.shields.io/nuget/dt/WallHavenClient?logo=nuget&style=flat-square)](https://www.nuget.org/packages/WallHavenClient/)
[![.NET](https://github.com/Bigtalljosh/WallHavenClient/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Bigtalljosh/WallHavenClient/actions/workflows/dotnet.yml)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://github.com/Bigtalljosh/WallHavenClient/blob/main/LICENSE)

# WallHavenClient

WallHavenClient is a simple wrapper around the [WallHaven](https://wallhaven.cc/) API.
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

```csharp
var _searchParams = new SearchParamsBuilder()
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

var result = await _wallHavenClient.Search(_searchParams);
```

Which should return you a result like :

```json
{
  "id": "e7ww6r",
  "url": "https://wallhaven.cc/w/e7ww6r",
  "short_url": "https://whvn.cc/e7ww6r",
  "uploader": null,
  "views": 5,
  "favorites": 3,
  "source": "https://www.artstation.com/pan",
  "purity": "sfw",
  "category": "general",
  "dimension_x": 3840,
  "dimension_y": 2160,
  "resolution": "3840x2160",
  "ratio": "1.78",
  "file_size": 7417712,
  "file_type": "image/jpeg",
  "created_at": "2021-09-03 20:05:14",
  "colors": [
    "#424153",
    "#000000",
    "#999999",
    "#663399",
    "#663300"
  ],
  "path": "https://w.wallhaven.cc/full/e7/wallhaven-e7ww6r.jpg",
  "thumbs": {
    "large": "https://th.wallhaven.cc/lg/e7/e7ww6r.jpg",
    "original": "https://th.wallhaven.cc/orig/e7/e7ww6r.jpg",
    "small": "https://th.wallhaven.cc/small/e7/e7ww6r.jpg"
  },
  "tags": null
}
```