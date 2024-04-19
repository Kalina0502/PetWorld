using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class Pets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24e9bcd9-7c87-491b-b1bc-582e0d52d241", "AQAAAAEAACcQAAAAEFBayv7qBmD5jY9zeSxv4SQxtQRU0puyAFLkue+VbHyTUf4m5UjWeCRKqfq+xr4/Gg==", "80e66ac0-1dfd-410c-b78a-9d8eb5141dbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "320b5c0c-864b-46cb-8a0f-4978e950d663", "AQAAAAEAACcQAAAAEOMarMOcqh5TW2rVrgRai+LXJX2ackDBp2IudzA88yMhf2N5MxcHPLU2ezvW7BcERw==", "5976ffbe-fcbb-4d44-b092-fb37c00732ca" });
        }
    }
}
