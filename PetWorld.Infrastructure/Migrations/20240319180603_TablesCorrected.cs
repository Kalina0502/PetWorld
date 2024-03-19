using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class TablesCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Species",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PetOwnerId",
                table: "PetOwners",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "GenderTypes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Pet gender");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_GenderId",
                table: "Pets",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_GenderTypes_GenderId",
                table: "Pets",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_GenderTypes_GenderId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_GenderId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Species",
                newName: "SpeciesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PetOwners",
                newName: "PetOwnerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GenderTypes",
                newName: "GenderId");
        }
    }
}
