namespace WallHaven.Client
{
    public record Config
    {
        public string APIKey { get; init; }
        public string BaseUrl { get; init; }
        public int MinHeight { get; init; }
        public int MinWidth { get; init; }
    }
}