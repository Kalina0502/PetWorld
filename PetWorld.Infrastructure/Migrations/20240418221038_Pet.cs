using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class Pet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
