using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class GednerTypeModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Pet image url");

            migrationBuilder.AlterColumn<string>(
                name: "PetOwnerLastName",
                table: "PetOwners",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                comment: "Pet owner last name",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Pet owner last name");

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
                values: new object[] { "11e57e4c-b176-44f3-b86a-a17f5b3ea789", "AQAAAAEAACcQAAAAEKrzKUPgPKtHCmQCe5XtxFPwQCBCJS5ihSREpJ/VA9BnkZg5YbVpyerjbaG0MmWGFQ==", "410bb7b6-8ce6-48fd-9616-75fde78d7dce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f7d319f-6b96-4309-8894-613ed3c7608a", "AQAAAAEAACcQAAAAEBa5r++ic6zBfzQ/7VZzQQAKTK1rmVh71KKx5hAviQBkjnZGxGwejEOI44UlPbZKPQ==", "0b5c7030-3c19-4059-8537-a420fa2f1aee" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners");

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

            migrationBuilder.AlterColumn<string>(
                name: "PetOwnerLastName",
                table: "PetOwners",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Pet owner last name",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldComment: "Pet owner last name");

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
                values: new object[] { "c5d32c06-fa06-4c09-8fd5-24111923471c", "AQAAAAEAACcQAAAAELHuGoXByf1YaZVz/akG8wJ4ZQQrI9HK2cVlK2Rc2bKHvlcPjIw7V2cC+LBmnY9Mlg==", "077df5d1-b4ca-4df8-9faa-a71a28e862c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3e40e14-d4e4-454b-8bf6-63dc27a41e3e", "AQAAAAEAACcQAAAAELbb/ralj1wTrE7ebuTuAPk6e4L5OI4eGD2qvF1fT4FlePLt7GoPF1Zco9YQZitweA==", "aa15dbf2-3b34-4d02-a205-ad1a12601602" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_GenderTypes_GenderId",
                table: "PetOwners",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
