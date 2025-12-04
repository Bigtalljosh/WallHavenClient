using System;

namespace WallHavenClient;

public class DeserializeException : Exception
{
    private const string NotFoundMessage = "Failed to Deserialise Response JSON.";

    public DeserializeException()
        : base(NotFoundMessage)
    {
    }

    public DeserializeException(string message)
        : base(NotFoundMessage + Environment.NewLine + message)
    {
    }

    public DeserializeException(string message, Exception innerException)
        : base(NotFoundMessage + Environment.NewLine + message, innerException)
    {
    }
}