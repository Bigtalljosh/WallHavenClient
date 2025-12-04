using System.Threading.Tasks;

namespace WallHavenClient;

public interface IWallHavenClient
{
    Task<WallHavenResponse> GetWallpaper(string id);
    Task<WallHavenResponse> Search(string searchParams);
}