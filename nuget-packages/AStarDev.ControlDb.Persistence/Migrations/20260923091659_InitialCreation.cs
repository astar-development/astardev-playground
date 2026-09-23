using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AStarDev.ControlDb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScrapeConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SiteName = table.Column<string>(type: "varchar(50)", nullable: false),
                    SiteUrl = table.Column<string>(type: "varchar(255)", nullable: false),
                    SearchCategoryPrefix = table.Column<string>(type: "varchar(255)", nullable: false),
                    SearchCategorySuffix = table.Column<string>(type: "varchar(255)", nullable: false),
                    TopWallpapers = table.Column<string>(type: "varchar(255)", nullable: false),
                    HotWallpapers = table.Column<string>(type: "varchar(255)", nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", nullable: false),
                    HashedPassword = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapeConfigurations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrapeConfigurations");
        }
    }
}
