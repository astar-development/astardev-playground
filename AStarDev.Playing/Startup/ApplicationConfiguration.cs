namespace AStarDev.Playing.Startup;

public record ApplicationConfiguration(string BaseDirectory)
{
    public string ControlDbConnectionString => $"Data Source={BaseDirectory}/ControlDb.db";
}