using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_GenderTypes_GenderId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_GenderId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4a15327-cc2a-4c64-9bc4-eee198167ab0", "AQAAAAEAACcQAAAAEJqijGimzl/XS0FbG+WgLIwULYkl+Xw1ynNL4YEiAO2zCHfs+5kWW+GO9jyGv3xIjw==", "770dcb35-8ecb-4d4f-ac7e-eb358689fd43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a62a1ddf-a127-423b-93dc-6d9f4bd7f6da", "AQAAAAEAACcQAAAAELmm5fHw51bskYdvjTta6wNben6OWPLkaCpNauF3Rx39DzHoYGWG7/gc8gSzBzUnCw==", "d3bd1716-f9ec-45a0-8df0-4779ed1c66fc" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Pet gender");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0cff93e-2d81-47d5-b9b0-0cfd4c7678f7", "AQAAAAEAACcQAAAAEFT6HT4NsqBO+LyrAx7g6SnUySWBC/kJ4YZm6HxdTgRo+ffogx5QVP6QvXtNUnwFtQ==", "c0112451-987e-4104-9e18-3bf8e12478e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978bc269-1037-4136-816d-c560a101c692", "AQAAAAEAACcQAAAAEE7MRRP/CajjIUqO0wk4VJgPX8B7RC4PgcS7KG3VSc+/KN6P3m28Y7pKcW4l4hEn5w==", "526c4da7-acbd-4c03-ad5e-e9035f549344" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenderId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_GenderId",
                table: "Pets",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_GenderTypes_GenderId",
                table: "Pets",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
