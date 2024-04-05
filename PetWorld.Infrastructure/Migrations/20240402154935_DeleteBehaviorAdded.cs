using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class DeleteBehaviorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Rooms",
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
                name: "AgentId",
                table: "Groomers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent identifier");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "GenderTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent identifier");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "AdoptionAnimals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Agent identifier");

            migrationBuilder.UpdateData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

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
                table: "GenderTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GenderTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GenderTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Groomers",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Groomers",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Groomers",
                keyColumn: "Id",
                keyValue: 3,
                column: "AgentId",
                value: 1);

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
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "AgentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
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
                name: "IX_Rooms_AgentId",
                table: "Rooms",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingTypes_AgentId",
                table: "GroomingTypes",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groomers_AgentId",
                table: "Groomers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTypes_AgentId",
                table: "GenderTypes",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAnimals_AgentId",
                table: "AdoptionAnimals",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionAnimals_Agents_AgentId",
                table: "AdoptionAnimals",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTypes_Agents_AgentId",
                table: "GenderTypes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groomers_Agents_AgentId",
                table: "Groomers",
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
                name: "FK_Rooms_Agents_AgentId",
                table: "Rooms",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionAnimals_Agents_AgentId",
                table: "AdoptionAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTypes_Agents_AgentId",
                table: "GenderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Groomers_Agents_AgentId",
                table: "Groomers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroomingTypes_Agents_AgentId",
                table: "GroomingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Agents_AgentId",
                table: "Rooms");

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
                name: "IX_Rooms_AgentId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_GroomingTypes_AgentId",
                table: "GroomingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Groomers_AgentId",
                table: "Groomers");

            migrationBuilder.DropIndex(
                name: "IX_GenderTypes_AgentId",
                table: "GenderTypes");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionAnimals_AgentId",
                table: "AdoptionAnimals");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "GroomingTypes");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Groomers");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "GenderTypes");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "AdoptionAnimals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "356bbe1d-31b5-47f9-a398-ce79089b3bb9", "AQAAAAEAACcQAAAAEHmduOlEfGNwB2K7r3New0oOxTVOTjzJRde8t3nj5YFTuTnzedCGnhDmMx3qU/A8kQ==", "1e9bedf7-6ae6-4c88-9a54-6bb85e577032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1115ef14-748a-4eac-80ea-af2b142133e2", "AQAAAAEAACcQAAAAEAllGh8A1bp3rTj37xXYledMAoPZSuPyR+TzNyEabrOK3rU/Ctj9S4U0VIa52J8Ytw==", "e8ca9674-c8c2-4b5b-9484-87cddcb3b68c" });
        }
    }
}
