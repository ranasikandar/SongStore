using Microsoft.EntityFrameworkCore.Migrations;

namespace SongStore.Migrations
{
    public partial class add2MoreSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772cda87-389e-443c-a7e1-05fb0ef7f67c",
                column: "ConcurrencyStamp",
                value: "de33e1d4-69a4-42c3-8c44-ac193e2630ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                column: "ConcurrencyStamp",
                value: "b785a4e3-7e87-42a6-b383-da64087c9790");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "9dd07991-3561-4d71-9b41-3665948543e3", "admin1@example.com", "AQAAAAEAACcQAAAAEExNpKgLtfL2+83X6bvMAv0B8jSQde2dB7koJRq/Omyn6qw8hS2SVf8DQ6EmWYrnxg==" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                columns: new[] { "ImageLocation", "SongFileLocation" },
                values: new object[] { "/img/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.jpeg", "/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.mp3" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                columns: new[] { "ImageLocation", "SongFileLocation" },
                values: new object[] { "/img/Song/Michael-Jackson-Billie-Jean.jpg", "/Song/Michael-Jackson-Billie-Jean.mp3" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 3,
                columns: new[] { "ImageLocation", "SongFileLocation" },
                values: new object[] { "/img/Song/Eminem_Lose-Yourself.jpg", "/Song/Eminem_Lose-Yourself.mp3" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "ArtistId", "GenreId", "ImageLocation", "IsDeleted", "SongFileLocation", "SongTitle", "YearRecorded" },
                values: new object[,]
                {
                    { 4, 2, 2, "/img/Song/Michael_Jackson_TheyDontCareAboutUs.jpg", false, "/Song/TheyDontCareAboutUs.mp3", "They Don't Care About Us", (short)1995 },
                    { 5, 3, 3, "/img/Song/eminem-love-the-way-you-lie.jpg", false, "/Song/eminem-love-the-way-you-lie.mp3", "watch me burn", (short)2010 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772cda87-389e-443c-a7e1-05fb0ef7f67c",
                column: "ConcurrencyStamp",
                value: "2131f3e2-ed8b-4463-ae6c-235a01330cc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                column: "ConcurrencyStamp",
                value: "24440680-129c-4a49-9b8e-945c7cb69040");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "86aa70d4-77a6-4229-add5-a2b272e2e5ff", "admin1@gmail.com", "AQAAAAEAACcQAAAAEIfZXPsTPYqxUX90xAPTdhLXD3ryvK0s96847Qzpv5N77AK73Ca4GDERw5i82tTebQ==" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                columns: new[] { "ImageLocation", "SongFileLocation" },
                values: new object[] { "img/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.jpeg", "Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.mp3" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                columns: new[] { "ImageLocation", "SongFileLocation" },
                values: new object[] { "img/Song/Michael-Jackson-Billie-Jean.jpg", "Song/Michael-Jackson-Billie-Jean.mp3" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 3,
                columns: new[] { "ImageLocation", "SongFileLocation" },
                values: new object[] { "img/Song/Eminem_Lose-Yourself.jpg", "Song/Eminem_Lose-Yourself.mp3" });
        }
    }
}
