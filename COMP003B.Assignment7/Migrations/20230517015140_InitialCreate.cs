using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.Assignment7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumTitle",
                columns: table => new
                {
                    AlbumTitle = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumTitle", x => x.AlbumTitle);
                });

            migrationBuilder.CreateTable(
                name: "ArtistViewModel",
                columns: table => new
                {
                    Artist = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistViewModel", x => x.Artist);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumTitle");

            migrationBuilder.DropTable(
                name: "ArtistViewModel");
        }
    }
}
