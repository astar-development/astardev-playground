namespace AStarDev.Utilities;

public static class ObjectExtensions
{
    extension (object obj)
    {
        public string ToJson()
            => System.Text.Json.JsonSerializer.Serialize(obj);
    }
}
