using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AStarDev.ControlDb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RestructureScrapeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_Username");

            migrationBuilder.RenameColumn(
                name: "TopWallpapers",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_TopWallpapers");

            migrationBuilder.RenameColumn(
                name: "SiteUrl",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_SiteUrl");

            migrationBuilder.RenameColumn(
                name: "SiteName",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_SiteName");

            migrationBuilder.RenameColumn(
                name: "SearchCategorySuffix",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_SearchCategorySuffix");

            migrationBuilder.RenameColumn(
                name: "SearchCategoryPrefix",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_SearchCategoryPrefix");

            migrationBuilder.RenameColumn(
                name: "HotWallpapers",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_HotWallpapers");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "ScrapeConfigurations",
                newName: "ScrapeSettings_HashedPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_Username",
                table: "ScrapeConfigurations",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_TopWallpapers",
                table: "ScrapeConfigurations",
                newName: "TopWallpapers");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_SiteUrl",
                table: "ScrapeConfigurations",
                newName: "SiteUrl");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_SiteName",
                table: "ScrapeConfigurations",
                newName: "SiteName");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_SearchCategorySuffix",
                table: "ScrapeConfigurations",
                newName: "SearchCategorySuffix");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_SearchCategoryPrefix",
                table: "ScrapeConfigurations",
                newName: "SearchCategoryPrefix");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_HotWallpapers",
                table: "ScrapeConfigurations",
                newName: "HotWallpapers");

            migrationBuilder.RenameColumn(
                name: "ScrapeSettings_HashedPassword",
                table: "ScrapeConfigurations",
                newName: "HashedPassword");
        }
    }
}
