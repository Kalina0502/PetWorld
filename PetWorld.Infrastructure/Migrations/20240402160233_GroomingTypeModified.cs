using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class GroomingTypeModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroomingTypes_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes");

            migrationBuilder.DropIndex(
                name: "IX_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes");

            migrationBuilder.DropColumn(
                name: "GroomingTypeId",
                table: "GroomingTypes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd01011b-4ad3-4702-93de-aa96df93961c", "AQAAAAEAACcQAAAAECuwvTjIYWzfDW1PZ9XAqaM6EemoqFFRbJndP8kq6HYHIN+7/rhEJ9vu4YW9qpKKnQ==", "3990cc5c-cc2a-4715-a784-f181c533c557" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6118adc-d16a-49ef-8f7b-536bc89e6784", "AQAAAAEAACcQAAAAEAB5KNXkLYrTcYC0fXOlBEgPjPQqUtsgk7cdgkSgaaBai5HO2ZjAwL1Pic9O07qs0w==", "9e5e4f47-6850-4b1b-850d-1826971ad9c3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroomingTypeId",
                table: "GroomingTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86a6fe7a-7f23-4491-bbe7-8f1b6b044d95", "AQAAAAEAACcQAAAAEC5t4HYFjnNIQmK2u/j67SVx3HnpauqfJ1TG7ZEnZR8ODXGRGTXLuN48pG9hM/ywlA==", "7ab77e2c-b996-4efa-b5e6-19b5b582b7d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4382808-6641-4786-953b-fd6f3ee9dd1f", "AQAAAAEAACcQAAAAEKVFx059YvWTaJtc2lbLVs14wGwu0/gQhC+GUAXKTk+nxV44x2iEQMySafnA3iLOEA==", "aa2ab451-85f4-41e3-b5f7-fe11dde739ce" });

            migrationBuilder.CreateIndex(
                name: "IX_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes",
                column: "GroomingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingTypes_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes",
                column: "GroomingTypeId",
                principalTable: "GroomingTypes",
                principalColumn: "Id");
        }
    }
}
