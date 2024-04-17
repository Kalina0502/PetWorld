using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
