using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetAndPetOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b754c98c-f828-4f4c-9367-1da59e9550aa", "AQAAAAEAACcQAAAAEFhSOaAkjfsq4M5Xsw1s16LJBqHFlajb5BAfahycd97JOAaSIYi6mlqpMAZfgR2TXw==", "94f8a6ef-1a8d-46f3-b3e2-055b933dc896" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89cf4f12-3d67-4b10-8ab6-dbb21c31c44c", "AQAAAAEAACcQAAAAEC94qvpEaftVbSKHoXlc5Myebol9sqh2SE+62Sy6h3V5i/nZC8qnde43wTcxSin6WA==", "6db907cf-0659-4d4e-bf89-418288969535" });
        }
    }
}
