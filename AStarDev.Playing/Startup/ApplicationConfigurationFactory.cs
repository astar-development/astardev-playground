namespace AStarDev.Playing.Startup;

public static class ApplicationConfigurationFactory
{
    public static ApplicationConfiguration Build(string baseDirectory)
        => new(baseDirectory);
}