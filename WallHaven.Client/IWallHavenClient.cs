namespace WallHaven.Client
{
    public interface IWallHavenClient
    {
        Task<WallHavenResponse> GetWallpaper(string id);
        Task<WallHavenResponse> Search(string searchParams);
    }
}