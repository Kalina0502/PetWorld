using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetUserIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the pet");

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

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_UserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72c70fd3-b804-485e-ba59-4bb6d46dbc95", "AQAAAAEAACcQAAAAEMjnas1JwTZ6K8ykG2B79J3bnbaN4t6fMRrZ4dVrUIEaCXlmWUhczPLhnswnQQ/VUA==", "684726e2-4337-4138-b573-6880c77f4856" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0daa04b4-6a36-4822-98b6-ab5e6b05e9b5", "AQAAAAEAACcQAAAAEJCJ0df45oDtUyOr/0JPEma1Aievr+JtpzhIOQdiWo0oQL/NAiOhauC1d4PkqxiREQ==", "3066ebc1-ee2f-4efb-a371-49270e86b5b8" });
        }
    }
}
