using Microsoft.EntityFrameworkCore.Migrations;

namespace SongStore.Migrations
{
    public partial class songTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    YearRecorded = table.Column<short>(type: "smallint", maxLength: 4, nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    ImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SongFileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "ArtistName", "ImageLocation", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Elvis Presley", "img/Artist/ElvisPresley.jpg", false },
                    { 2, "Michael Jackson", "img/Artist/MichaelJackson.jpg", false },
                    { 3, "Eminem", "img/Artist/Eminem.jpg", false }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772cda87-389e-443c-a7e1-05fb0ef7f67c",
                column: "ConcurrencyStamp",
                value: "7002764b-6066-40e6-9422-edfc165399ee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                column: "ConcurrencyStamp",
                value: "699baca2-c9f0-428e-8c51-e3ee2626c568");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "274e3b12-ddb3-4d17-ad62-f71ac2eae5ec", "AQAAAAEAACcQAAAAEM2KkopuqVOXqhAhgE0nCNiF2N/eEsPvroHdfVguoThJZGr5HZ/9IOnyyXKnlqm4gw==" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "GenreName", "ImageLocation", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Rock", "img/Genre/Rock.jpg", false },
                    { 2, "Pop", "img/Genre/Pop.jpg", false },
                    { 3, "Hip-Hop", "img/Genre/Hip-Hop.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "ArtistId", "GenreId", "ImageLocation", "SongFileLocation", "SongTitle", "YearRecorded" },
                values: new object[] { 1, 1, 1, "/img/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.jpeg", "/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.mp3", "Jailhouse Rock", (short)1957 });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "ArtistId", "GenreId", "ImageLocation", "SongFileLocation", "SongTitle", "YearRecorded" },
                values: new object[] { 2, 2, 2, "/img/Song/Michael-Jackson-Billie-Jean.jpg", "/Song/Michael-Jackson-Billie-Jean.mp3", "Billie Jean", (short)1982 });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "ArtistId", "GenreId", "ImageLocation", "SongFileLocation", "SongTitle", "YearRecorded" },
                values: new object[] { 3, 3, 3, "/img/Song/Eminem_Lose-Yourself.jpg", "/Song/Eminem_Lose-Yourself.mp3", "Lose Yourself", (short)2002 });

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistId",
                table: "Song",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772cda87-389e-443c-a7e1-05fb0ef7f67c",
                column: "ConcurrencyStamp",
                value: "f609d67f-9aa1-40c4-9e98-2136ae7fdf3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                column: "ConcurrencyStamp",
                value: "0a23f101-a508-4d26-b96f-f8b4a92149bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f76a38e-66d5-44b4-8a74-ad6120097706", "AQAAAAEAACcQAAAAEFF5tcPLOwQho8RkC7cTZ7LS1vuEo66UCGRJw3ad7+W1DFTFy7n6o7GWynfZOmZoeA==" });
        }
    }
}
