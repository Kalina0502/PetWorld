using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class ModifiedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenderTypes_Agents_AgentId",
                table: "GenderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_GroomingTypes_Agents_AgentId",
                table: "GroomingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_GroomingTypes_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_Agents_AgentId",
                table: "RoomTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Agents_AgentId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_AgentId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_AgentId",
                table: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_GroomingTypes_AgentId",
                table: "GroomingTypes");

            migrationBuilder.DropIndex(
                name: "IX_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes");

            migrationBuilder.DropIndex(
                name: "IX_GenderTypes_AgentId",
                table: "GenderTypes");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "GroomingTypes");

            migrationBuilder.DropColumn(
                name: "GroomingTypeId",
                table: "GroomingTypes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent identifier");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent identifier");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "GroomingTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent identifier");

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

            migrationBuilder.UpdateData(
                table: "GroomingTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GroomingTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GroomingTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4,
                column: "AgentId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Species_AgentId",
                table: "Species",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_AgentId",
                table: "RoomTypes",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingTypes_AgentId",
                table: "GroomingTypes",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes",
                column: "GroomingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTypes_AgentId",
                table: "GenderTypes",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTypes_Agents_AgentId",
                table: "GenderTypes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingTypes_Agents_AgentId",
                table: "GroomingTypes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingTypes_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes",
                column: "GroomingTypeId",
                principalTable: "GroomingTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_Agents_AgentId",
                table: "RoomTypes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Agents_AgentId",
                table: "Species",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
