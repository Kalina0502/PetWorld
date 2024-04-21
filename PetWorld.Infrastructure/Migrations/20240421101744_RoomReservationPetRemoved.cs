using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class RoomReservationPetRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Pets_PetId",
                table: "RoomReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomReservations_PetId",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "RoomReservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c86832f-aa12-4cb4-9851-a2a766cc6fa1", "AQAAAAEAACcQAAAAEBA/H8zf6WfmROKrgWvmfnL4KP6m9YLds+WX8W5DBWUC+JYthAJImEhAYUzz+RvAdg==", "ca427238-2790-4596-ba15-b65516999a10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cca3fc3-4c66-460e-95ef-82331e2a63e8", "AQAAAAEAACcQAAAAEFbKh/F0uexlNMFRqHaBDruTyo9HE2g0AbBzZSpRlpQQM763BmwbfnrZIq+LkxsNyQ==", "80ebc595-055d-4e4f-bc85-1ddcc82cb9e7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "RoomReservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Pet identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95965392-1ed0-45d7-906a-7e14d1aa3d7d", "AQAAAAEAACcQAAAAEGyvoMB6uOzjPZMGJnLfsZZq7OWgx+bhX/qI4FTO5VAHgPl5SXO4rGqNLETJPEZCVA==", "f7d41f4a-bd1e-497e-84e6-689e45453346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3c16737-4b72-4fcf-9721-3fad13b498d3", "AQAAAAEAACcQAAAAED/EiH+nGoQ/00qozdIUD8A0gOHTo7YZpCNlzEdoAIKVB2PzP5LQo6UcbSOA8767sA==", "b57d4775-425a-47de-a79a-ec377cc26693" });

            migrationBuilder.UpdateData(
                table: "RoomReservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomReservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PetId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_PetId",
                table: "RoomReservations",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Pets_PetId",
                table: "RoomReservations",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
