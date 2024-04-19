using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetOwnerLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
