using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class UniqueConstraintAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12b97129-ece6-4dd1-b9f6-0dfb626d1e61", "AQAAAAEAACcQAAAAEOGXTxLJpka4639d7N5dRAg1aTq/3k8JJAQ7MdfHMoJK6qLStSU6cYAN5mrv4X6+Ww==", "b0e5b7fb-c02a-48e7-b50e-0666f363c81d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5507d568-fa1f-4988-aec5-e70771e4f959", "AQAAAAEAACcQAAAAEF4MmczQGjEqEBTX5SYeau56XpxQqKialgBaxvp9P2oXJiYs06QtRyoNiV81kHJLqg==", "0d730f5e-4ae6-470f-9e89-28596104a5cb" });
        }
    }
}
