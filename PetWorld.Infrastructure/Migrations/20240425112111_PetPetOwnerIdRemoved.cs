using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class PetPetOwnerIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08d5c2f6-a5b0-4dfa-9b0e-bd5c4503f2f5", "AQAAAAEAACcQAAAAECYUXDlfA02o1/HnAIKZXvYjecWnt6MAKama8qchdZjpmLIxRIH8MlJ6k3p0/H5bWg==", "4d1a464c-9f2d-4b94-8a92-4b5b0d9dbd9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "496daabd-fba4-48c7-ac26-668c55b21037", "AQAAAAEAACcQAAAAEJ4CvVSJ23hAIPFW5MbAUtQy5/PAvtoicfaAH9Rtb5H6lf76ETF084yE94Fp4ac90w==", "2823e875-c5a1-4d90-a03c-fc09483c9164" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetOwnerId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Pet owner");

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

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PetOwnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PetOwnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "PetOwnerId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
