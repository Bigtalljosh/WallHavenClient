using System;

namespace WallHavenClient;

public class NotFoundException : Exception
{

    private const string NotFoundMessage = "Wallpaper with specified ID cannot be found.";

    public NotFoundException()
        : base(NotFoundMessage)
    {
    }

    public NotFoundException(string message)
        : base(NotFoundMessage + Environment.NewLine + message)
    {
    }

    public NotFoundException(string message, Exception innerException)
        : base(NotFoundMessage + Environment.NewLine + message, innerException)
    {
    }
}
