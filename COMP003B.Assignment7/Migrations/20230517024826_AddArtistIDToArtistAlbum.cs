using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.Assignment7.Migrations
{
    /// <inheritdoc />
    public partial class AddArtistIDToArtistAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistAlbumViewModel",
                columns: table => new
                {
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlbumId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistAlbumViewModel", x => x.ArtistId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistAlbumViewModel");
        }
    }
}
