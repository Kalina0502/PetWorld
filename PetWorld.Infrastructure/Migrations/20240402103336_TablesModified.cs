using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class TablesModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroomingServices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "AdoptionAnimals",
                type: "int",
                nullable: false,
                comment: "Species",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "GroomingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ServiceType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the service"),
                    GroomingTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingTypes_GroomingTypes_GroomingTypeId",
                        column: x => x.GroomingTypeId,
                        principalTable: "GroomingTypes",
                        principalColumn: "Id");
                },
                comment: "Service Type description");

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Reservation identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false, comment: "Room"),
                    PetId = table.Column<int>(type: "int", nullable: false, comment: "Pet"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-in date"),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-out date"),
                    IncludesFood = table.Column<bool>(type: "bit", nullable: false, comment: "Includes food"),
                    IncludesWalk = table.Column<bool>(type: "bit", nullable: false, comment: "Includes walk")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Reservation description");

            migrationBuilder.CreateTable(
                name: "GroomingReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(type: "int", nullable: false, comment: "Pet"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-in date"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-out date"),
                    GroomerId = table.Column<int>(type: "int", nullable: false),
                    GroomingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingReservations_Groomers_GroomerId",
                        column: x => x.GroomerId,
                        principalTable: "Groomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroomingReservations_GroomingTypes_GroomingTypeId",
                        column: x => x.GroomingTypeId,
                        principalTable: "GroomingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroomingReservations_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdoptionAnimals",
                columns: new[] { "Id", "Age", "City", "Description", "ImageUrl", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 3, "Varna", "Friendly dog looking for a forever home.", "https://example.com/fluffy.jpg", "Fluffy", 1 },
                    { 2, 2, "Sofia", "Playful cat in need of a loving family.", "https://example.com/whiskers.jpg", "Whiskers", 2 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "356bbe1d-31b5-47f9-a398-ce79089b3bb9", "AQAAAAEAACcQAAAAEHmduOlEfGNwB2K7r3New0oOxTVOTjzJRde8t3nj5YFTuTnzedCGnhDmMx3qU/A8kQ==", "1e9bedf7-6ae6-4c88-9a54-6bb85e577032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1115ef14-748a-4eac-80ea-af2b142133e2", "AQAAAAEAACcQAAAAEAllGh8A1bp3rTj37xXYledMAoPZSuPyR+TzNyEabrOK3rU/Ctj9S4U0VIa52J8Ytw==", "e8ca9674-c8c2-4b5b-9484-87cddcb3b68c" });

            migrationBuilder.InsertData(
                table: "Groomers",
                columns: new[] { "Id", "Age", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 23, "Professional groomers providing high-quality grooming services.", "Kalina Yordanova" },
                    { 2, 30, "Dedicated groomers offering personalized grooming sessions for your pets.", "Constantine Nenov" },
                    { 3, 27, "Experienced groomers who love pampering your furry friends.", "Rosica Yordanova" }
                });

            migrationBuilder.InsertData(
                table: "GroomingTypes",
                columns: new[] { "Id", "GroomingTypeId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Bath and Brush" },
                    { 2, null, "Haircut" },
                    { 3, null, "Nail Trim" }
                });

            migrationBuilder.InsertData(
                table: "RoomReservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "IncludesFood", "IncludesWalk", "PetId", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, 1 },
                    { 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroomingReservations",
                columns: new[] { "Id", "EndTime", "GroomerId", "GroomingTypeId", "PetId", "StartTime" },
                values: new object[] { 1, new DateTime(2024, 4, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, new DateTime(2024, 4, 24, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GroomingReservations",
                columns: new[] { "Id", "EndTime", "GroomerId", "GroomingTypeId", "PetId", "StartTime" },
                values: new object[] { 2, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, new DateTime(2024, 4, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_GroomingReservations_GroomerId",
                table: "GroomingReservations",
                column: "GroomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingReservations_GroomingTypeId",
                table: "GroomingReservations",
                column: "GroomingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingReservations_PetId",
                table: "GroomingReservations",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingTypes_GroomingTypeId",
                table: "GroomingTypes",
                column: "GroomingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_PetId",
                table: "RoomReservations",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_RoomId",
                table: "RoomReservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroomingReservations");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.DropTable(
                name: "GroomingTypes");

            migrationBuilder.DeleteData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdoptionAnimals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groomers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groomers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groomers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "AdoptionAnimals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Species");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Reservation identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(type: "int", nullable: false, comment: "Pet"),
                    RoomId = table.Column<int>(type: "int", nullable: false, comment: "Room"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-in date"),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-out date"),
                    IncludesFood = table.Column<bool>(type: "bit", nullable: false, comment: "Includes food"),
                    IncludesWalk = table.Column<bool>(type: "bit", nullable: false, comment: "Includes walk")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Reservation description");

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ServiceType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the service")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                },
                comment: "Service Type description");

            migrationBuilder.CreateTable(
                name: "GroomingServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Grooming Service identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroomerId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of service")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingServices_Groomers_GroomerId",
                        column: x => x.GroomerId,
                        principalTable: "Groomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroomingServices_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroomingServices_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Grooming Service description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b089c14-4b1b-4375-a323-47ec74bcaf49", "AQAAAAEAACcQAAAAEDwFlmzzIaYZAiQB0OuCKxXzXUxUeYlTPaiAfsVfbmwOAVQfywSsUXRt8x7Hnr3Seg==", "36ad2563-27f0-403f-9a71-d86c4d4b35bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8ee1f2e-65a9-4d96-b041-02b4af414c4d", "AQAAAAEAACcQAAAAEN4/jFFFI8LUT5ojVDgbYRl0p01ExVqVC10iq/5V5RhsbQmWnE0Xbm6IFGrDNqBndQ==", "42a3f23d-631e-45ea-93ba-051e52e2ed39" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "IncludesFood", "IncludesWalk", "PetId", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, 1 },
                    { 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroomingServices_GroomerId",
                table: "GroomingServices",
                column: "GroomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingServices_PetId",
                table: "GroomingServices",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingServices_ServiceTypeId",
                table: "GroomingServices",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PetId",
                table: "Reservations",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }
    }
}
