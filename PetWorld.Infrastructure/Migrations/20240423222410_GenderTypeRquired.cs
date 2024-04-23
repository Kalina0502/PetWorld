using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class GenderTypeRquired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners");

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
                values: new object[] { "a893f457-0631-41a9-8771-3ac258ac71b7", "AQAAAAEAACcQAAAAEM3uYW9dfmIn+UYZvUe5gSLlRaXyFYz0Gzw0kpj87pnP8dKBPTe5fY0fbRhrNGIePQ==", "9b251154-894a-4711-8ad7-ce6c4d87b64a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38bfffd3-ac96-4e59-81e9-8cd21c188e5d", "AQAAAAEAACcQAAAAEG6qxWWMKjSX4xY4r/FSCgMJMN5P2GUjCyObWDXCWZ6AyTd4mp4bAJ5NafU0lj0ICA==", "682ef884-5f34-4dd8-8355-bd0a915429c3" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners");

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
                values: new object[] { "f52fc14b-5719-4b2f-83e8-2f57cb753807", "AQAAAAEAACcQAAAAENRSxZaGB0SqxTIkXdJF9cGqc2L8qEfAeEITkcW5pc/dFvQs0G95ClXWC/VVBQ8+Zw==", "a0bbe1f3-2b66-4861-8b2e-88199a035f25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4885094-0773-4401-b3be-b763651b4097", "AQAAAAEAACcQAAAAEE7ABlsdnZrOxWyghzg+7/arUin01DRv3nfEq7JJdFB1BV77qd5WYBI1HYZE6+Fh3w==", "4543d4f3-7f17-4da9-8ac3-aaaee23b096d" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id");
        }
    }
}
