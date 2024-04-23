using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class EmailModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PetOwners_Email",
                table: "PetOwners");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "PetOwners_Email",
                table: "PetOwners",
                column: "Email",
                unique: true);
        }
    }
}
