using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Pets_PetId",
                table: "RoomReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomReservations_PetId",
                table: "RoomReservations");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "RoomReservations");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
                type: "int",
                nullable: false,
                comment: "RoomType identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Rooms",
                type: "bit",
                nullable: false,
                comment: "Is Available",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "RoomReservations",
                type: "int",
                nullable: false,
                comment: "Room identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Room");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoomReservations",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the pet");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Pet image url");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "PetOwners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39a7b023-c51b-461f-bd5d-f47f3597c37c", "AQAAAAEAACcQAAAAEKKI+LwfjmTSfN9oN4ewInstFS0VzXiZbb+jVx9iypkPE19PpxlxQWM6Cc/9tjRvMA==", "8cdb2e01-7d66-4134-a0f4-cc361face48c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94ff2313-ca87-4474-8a60-758964bcc017", "AQAAAAEAACcQAAAAEBLIz6MLb2uVE7T1IDoMZuV8Ua64yhAnZFG+dBtBOCJR1/sXQFwvWdiW4DvlZrUuIw==", "af3cb335-8187-4ee3-bd88-d6e17efec6ce" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomReservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_UserId",
                table: "RoomReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_AspNetUsers_UserId",
                table: "RoomReservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_AspNetUsers_UserId",
                table: "RoomReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomReservations_UserId",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoomReservations");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "RoomType identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Rooms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is Available");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "RoomReservations",
                type: "int",
                nullable: false,
                comment: "Room",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Room identifier");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "RoomReservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Pet");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Pet image url",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "PetOwners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c1c09e9-57d5-4d0c-af1f-d3898e00cd9e", "AQAAAAEAACcQAAAAEAV2mlcZs1jIXZOufllYIC2Vuf77jTUfHiT9cyZHtHyb/f/KZCbWB+FPvBntkadH/g==", "98f67bc4-2142-4f0d-8ac8-ed08ee8fbbe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d23480a5-496e-403a-9309-70447addd5fb", "AQAAAAEAACcQAAAAEB7B1j/OXwA8ntsx+/yw95Enpyit1tufZHoSmyXDklJ9ncp8CuGltZFMvttCJvFLtg==", "803a3d17-0966-4ad7-a45c-ba77eaab947a" });

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
                columns: new[] { "CheckInDate", "CheckOutDate", "PetId" },
                values: new object[] { new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Bird Room" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AgentId", "IsAvailable", "RoomTypeId" },
                values: new object[] { 3, 1, false, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_PetId",
                table: "RoomReservations",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
