namespace AStarDev.ControlDb.Persistence;

/// <summary>Represents the unique identifier for a ScrapeConfiguration.</summary>
public static class ScrapeConfigIdHelpers
{
    extension(ScrapeConfigurationId)
    {
        /// <summary>Gets an empty ScrapeConfigurationId.</summary>
        public static ScrapeConfigurationId Empty => new(Guid.Empty);

        /// <summary>Creates a new ScrapeConfigurationId with a version 7 GUID.</summary>
        public static ScrapeConfigurationId Create => new(Guid.CreateVersion7());
    }
}
