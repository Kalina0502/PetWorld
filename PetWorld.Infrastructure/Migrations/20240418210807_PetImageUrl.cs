using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Pet image url");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9862be33-982e-4256-bf01-2f083c9fadfb", "AQAAAAEAACcQAAAAEEAEMlWwOC7zyACKXC+GLxaFn+i46KsbyOWXyubmkIt2nsTaaSH3XMKYdfhAaRpMNQ==", "3c2615fd-fb57-4da9-bf7f-012bc18654cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1d93a5a-ec49-45e8-bf9b-8c6389b8b8b2", "AQAAAAEAACcQAAAAEOMy0aG7+tlMT1IR5ggdC7ZGiHWy4eZRAvheWZf/HvYr1u7VbUFHocokJ3jGi3If2g==", "a86b3964-0f60-4047-87ff-ea0e1acc14f1" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f59c5f59-11ae-472f-8c97-76477f5b9a99", "AQAAAAEAACcQAAAAEKM0MmgA+IDaS1P/8Wt7QRi7mWUnfQK/bp3OjwB393xDjt/BIAJL0Lx4YfKF33rW7A==", "9d9a3bcc-cbaf-48e5-bfa7-45b137fcc187" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f30e36eb-f46a-41cc-be9f-c00e4d0d7e45", "AQAAAAEAACcQAAAAELVTziDb02d/giPygYtvRdIzER41ZjP75WdciU5uoIuHur+VrlFq2j5x9+WQWuy8uA==", "b45394f8-282e-4641-8366-098670e05be1" });
        }
    }
}
