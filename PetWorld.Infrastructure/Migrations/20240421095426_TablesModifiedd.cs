using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class TablesModifiedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "RoomReservations",
                type: "int",
                nullable: false,
                comment: "Pet identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Pet");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "RoomReservations",
                type: "int",
                nullable: false,
                comment: "Pet",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Pet identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cab2490-8e1c-4b90-ac82-f8c68a27d1cb", "AQAAAAEAACcQAAAAEK332vkj3e4SPBuxx4SkLNiw3FpVI17YMbDMdWLycBZbFyvqU8Pcv14G7X/snyFqNg==", "453c63bc-c71f-44cd-a43f-3a44bbefecc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fdefda7-0d45-4f48-85c8-ff69ead20f56", "AQAAAAEAACcQAAAAEEN3fcy8u4SyF+VPbFEO1A45Pk0Z545PXKZmGW6A50xR62+j0Nwd24CbvWQqo/vE7Q==", "79eead9a-35c7-43df-b19a-7400436de929" });
        }
    }
}
