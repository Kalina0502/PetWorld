using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class RealImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AdoptionAnimals",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the pet");

            migrationBuilder.UpdateData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://imgs.search.brave.com/6_mK4szCUhPtgYpWPnxvThzz8t1gjuxplafy-36PLLo/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTMw/MTgzOTExMi9waG90/by9wdXBweS13aXRo/LXRpbHRlZC1oZWFk/LWFuZC1jcm9zc2Vk/LXBhd3MtbHlpbmct/b24tc29mYS5qcGc_/cz02MTJ4NjEyJnc9/MCZrPTIwJmM9ak1x/TllGMXRPZGpIa2pP/QjZnTGdLbFc0V3I1/OGdzUWJIYnI4MnBK/Q0dpRT0");

            migrationBuilder.UpdateData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://imgs.search.brave.com/yUi94EMJUyOlxg2hDIkB884GABSL4Cy8XSt8L314Hqg/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/ZnJlZS1waG90by9w/b3J0cmFpdC1hZG9y/YWJsZS1kb21lc3Rp/Yy1jYXRfMjMtMjE0/OTE2NzA4OC5qcGc_/c2l6ZT02MjYmZXh0/PWpwZw");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc13409f-6ca0-4bad-8c5c-5af63b468553", "AQAAAAEAACcQAAAAECwOyCQmaog6syez+U0HyQyJ6coXmi1WCyaxyetTDb+inEXXaBetbyfR374nOSIENg==", "e4902ceb-21c2-438e-8910-2ffd3eed887b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e678679-555c-4e3a-ad23-56e64ad16014", "AQAAAAEAACcQAAAAEPQNnGwxI9/wiciVG9XWH5SH/M/YRWg8dp/u/7yTyxbTKk3/ZJjGs70HsKpHV7GuHw==", "7ca9aeff-4585-4ce6-ba69-dce23f034484" });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAnimals_UserId",
                table: "AdoptionAnimals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAnimals_AspNetUsers_UserId",
                table: "AdoptionAnimals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAnimals_AspNetUsers_UserId",
                table: "AdoptionAnimals");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionAnimals_UserId",
                table: "AdoptionAnimals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AdoptionAnimals");

            migrationBuilder.UpdateData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/fluffy.jpg");

            migrationBuilder.UpdateData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/whiskers.jpg");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7ccbb70-308d-4860-8059-dad7f19dcf38", "AQAAAAEAACcQAAAAECgs3H4a3ytm9RbrYVURK0BLdo4PKM7RMg6emRJlYHBvZybgC/D3pjajHSMof7UCUA==", "4399e9f7-24aa-47f9-871b-a37774bfdbce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af77441-d749-4ec0-9873-fdc4d5ab5397", "AQAAAAEAACcQAAAAEOh+s4LSDNmif5RihXY323gZ94k8aexMglJ2Q5uuKSk2n4IVhwRPDBrdOeUmx89kxQ==", "6ec8a0ea-9952-41d3-be2a-aa2d4afdff63" });
        }
    }
}
