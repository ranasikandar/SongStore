using Microsoft.EntityFrameworkCore.Migrations;

namespace SongStore.Migrations
{
    public partial class editSongTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Genre_GenreId",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameIndex(
                name: "IX_Song_GenreId",
                table: "Songs",
                newName: "IX_Songs_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_ArtistId",
                table: "Songs",
                newName: "IX_Songs_ArtistId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Songs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "ArtistId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772cda87-389e-443c-a7e1-05fb0ef7f67c",
                column: "ConcurrencyStamp",
                value: "e62a85c7-f253-4113-9088-1c95967eec78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                column: "ConcurrencyStamp",
                value: "8319ca4f-7f61-4c1c-824a-90a1fcb29ba2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "304a0bc6-d6ac-4dd3-8c64-9fc6bc62a456", "AQAAAAEAACcQAAAAEDPepFYP0BxvKV9BV4if+OqcjuSyFybY7B5zhA8aC2iQ3qITHpJ3882KHMo7mDpC3Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_GenreId",
                table: "Song",
                newName: "IX_Song_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_ArtistId",
                table: "Song",
                newName: "IX_Song_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "ArtistId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Genre_GenreId",
                table: "Song",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
