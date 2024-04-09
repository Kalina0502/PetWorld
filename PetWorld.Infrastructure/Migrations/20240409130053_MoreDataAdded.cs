using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class MoreDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Pets",
                type: "int",
                nullable: false,
                comment: "Species identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Species");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Pets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "AdoptionAnimals",
                type: "int",
                nullable: false,
                comment: "Species identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Species");

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

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: "Varna");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "Sofia");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "City",
                value: "Burgas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Pets",
                type: "int",
                nullable: false,
                comment: "Species",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Species identifier");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "AdoptionAnimals",
                type: "int",
                nullable: false,
                comment: "Species",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Species identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c751e3b6-cbcb-4b3c-a5b3-9b14340edca9", "AQAAAAEAACcQAAAAEGXepmzRpE6FrPo++GyKBknMdeIPi2TKTveore+yMhAvIGaCDe2d7kqfVRUkhBoSdg==", "dbbb8949-8bce-41c7-bff6-3ce23048e315" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb0ca64c-d29e-4371-b9b6-f12ef17112f1", "AQAAAAEAACcQAAAAEFaJJXD9XKkWyG7LQhZUGM6dNpAqAlJxh55tz8DFsRj478fsm9pUr3i26BgjYC67BQ==", "e95acce9-ed64-486b-9913-16b1b1c595d8" });
        }
    }
}
