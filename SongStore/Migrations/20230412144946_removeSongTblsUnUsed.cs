using Microsoft.EntityFrameworkCore.Migrations;

namespace SongStore.Migrations
{
    public partial class removeSongTblsUnUsed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocation",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ImageLocation",
                table: "Artists");

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "86aa70d4-77a6-4229-add5-a2b272e2e5ff", "admin1@example.com", "admin1@example.com", "admin1", "AQAAAAEAACcQAAAAEIfZXPsTPYqxUX90xAPTdhLXD3ryvK0s96847Qzpv5N77AK73Ca4GDERw5i82tTebQ==", "admin1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLocation",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLocation",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "ImageLocation",
                value: "img/Artist/ElvisPresley.jpg");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2,
                column: "ImageLocation",
                value: "img/Artist/MichaelJackson.jpg");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 3,
                column: "ImageLocation",
                value: "img/Artist/Eminem.jpg");

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "304a0bc6-d6ac-4dd3-8c64-9fc6bc62a456", "admin@gmail.com", "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEDPepFYP0BxvKV9BV4if+OqcjuSyFybY7B5zhA8aC2iQ3qITHpJ3882KHMo7mDpC3Q==", "admin" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "ImageLocation",
                value: "img/Genre/Rock.jpg");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "ImageLocation",
                value: "img/Genre/Pop.jpg");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "ImageLocation",
                value: "img/Genre/Hip-Hop.jpg");
        }
    }
}
