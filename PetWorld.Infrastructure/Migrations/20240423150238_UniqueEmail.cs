using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class UniqueEmail : Migration
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f52fc14b-5719-4b2f-83e8-2f57cb753807", "guest1@mail.com", "AQAAAAEAACcQAAAAENRSxZaGB0SqxTIkXdJF9cGqc2L8qEfAeEITkcW5pc/dFvQs0G95ClXWC/VVBQ8+Zw==", "a0bbe1f3-2b66-4861-8b2e-88199a035f25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4885094-0773-4401-b3be-b763651b4097", "AQAAAAEAACcQAAAAEE7ABlsdnZrOxWyghzg+7/arUin01DRv3nfEq7JJdFB1BV77qd5WYBI1HYZE6+Fh3w==", "4543d4f3-7f17-4da9-8ac3-aaaee23b096d" });

            migrationBuilder.CreateIndex(
                name: "PetOwners_Email",
                table: "PetOwners",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_AspNetUsers_UserId",
                table: "PetOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_AspNetUsers_UserId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "PetOwners_Email",
                table: "PetOwners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3f0edba-bb78-4331-a006-6152b214b372", "guest@mail.com", "AQAAAAEAACcQAAAAEJD63SBUos6qU16GCV/qnj8sThPbNAYWpXM7QxjpvumX1VAPPBB4b5DPRuNo7yl6gw==", "19d29ea3-e61f-4f93-be8e-37df560d6aef" });

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
    }
}
