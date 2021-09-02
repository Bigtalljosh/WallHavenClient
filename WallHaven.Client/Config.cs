namespace WallHavenClient
{
    public record Config
    {
        public string? APIKey { get; init; }
        public string BaseUrl { get; init; }
    }
}