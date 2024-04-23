using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetOwnerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_AspNetUsers_UserId",
                table: "PetOwners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3f0edba-bb78-4331-a006-6152b214b372", "AQAAAAEAACcQAAAAEJD63SBUos6qU16GCV/qnj8sThPbNAYWpXM7QxjpvumX1VAPPBB4b5DPRuNo7yl6gw==", "19d29ea3-e61f-4f93-be8e-37df560d6aef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31036cae-d367-4341-b955-e21bcaa8d249", "AQAAAAEAACcQAAAAECG6/OzAkjCKSFFIon/tpjHLfAGSF7UMS88M0iITJiCtullfaTTo5rECF/jCvuNW0A==", "0a3b0af5-c65b-4569-bdaa-5ede418eb830" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_AspNetUsers_UserId",
                table: "PetOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_AspNetUsers_UserId",
                table: "PetOwners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39a7b023-c51b-461f-bd5d-f47f3597c37c", "AQAAAAEAACcQAAAAEKKI+LwfjmTSfN9oN4ewInstFS0VzXiZbb+jVx9iypkPE19PpxlxQWM6Cc/9tjRvMA==", "8cdb2e01-7d66-4134-a0f4-cc361face48c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94ff2313-ca87-4474-8a60-758964bcc017", "AQAAAAEAACcQAAAAEBLIz6MLb2uVE7T1IDoMZuV8Ua64yhAnZFG+dBtBOCJR1/sXQFwvWdiW4DvlZrUuIw==", "af3cb335-8187-4ee3-bd88-d6e17efec6ce" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_AspNetUsers_UserId",
                table: "PetOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
