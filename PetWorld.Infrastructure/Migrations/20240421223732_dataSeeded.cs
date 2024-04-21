using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class dataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "GenderType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroomingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ServiceType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the service")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingTypes", x => x.Id);
                },
                comment: "Service Type description");

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "RoomType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "RoomType")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Species identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Species Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                },
                comment: "Species description");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Agent's phone"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "PetWorld agent");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Pet owner identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetOwnerFirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Pet owner first name"),
                    PetOwnerLastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Pet owner last name"),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false, comment: "Pet Owner email"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Pet owner phone number"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Pet owner age"),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetOwners_GenderTypes_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderTypes",
                        principalColumn: "Id");
                },
                comment: "Pet Owner");

            migrationBuilder.CreateTable(
                name: "AdoptionAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Pet identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Pet name"),
                    Age = table.Column<int>(type: "int", nullable: true, comment: "Pet age"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Pet city"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Pet for adopting"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false, comment: "Species identifier"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Pet image url"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "User id of the pet")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionAnimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionAnimals_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdoptionAnimals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdoptionAnimals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Addoption description");

            migrationBuilder.CreateTable(
                name: "Groomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Groomer identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Groomer name"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Groomer age"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Groomer short description"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groomers_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Groomer description");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Room identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false, comment: "RoomType identifier"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "Is Available"),
                    AgentId = table.Column<int>(type: "int", nullable: false, comment: "Agent identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Room description");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Pet identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Pet name"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Pet age"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false, comment: "Species identifier"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Pet description"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetOwnerId = table.Column<int>(type: "int", nullable: false, comment: "Pet owner"),
                    GenderId = table.Column<int>(type: "int", nullable: false, comment: "Pet gender")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_GenderTypes_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_PetOwners_PetOwnerId",
                        column: x => x.PetOwnerId,
                        principalTable: "PetOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Pet description");

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Reservation identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false, comment: "Room identifier"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-in date"),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Check-out date"),
                    IncludesFood = table.Column<bool>(type: "bit", nullable: false, comment: "Includes food"),
                    IncludesWalk = table.Column<bool>(type: "bit", nullable: false, comment: "Includes walk"),
                    RoomId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id");
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "d2151026-e237-41e6-b805-20d7f4da5a81", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEIuRhZO2aWCtJUl0ZOfYJ2KbYlYnqkFIpChjJtUqI62xHDLJS+a4uRp+/5y8hvSKWQ==", null, false, "d3b4b114-dfc4-4ac5-937e-ae720caf08df", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "bad50921-a32d-4ad7-bb3a-c0aa0c608e96", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEHDaRNJnBhiIlbBNK9faaDBjq4nIOa6BnScj6ZHjA7SiuxgAgFX9ZWQpK4JoS5GrfQ==", null, false, "b2255055-4f85-403b-a9ee-41915b5ce03b", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "GenderTypes",
                columns: new[] { "Id", "AgentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Male" },
                    { 2, 1, "Female" },
                    { 3, 1, "Other" }
                });

            migrationBuilder.InsertData(
                table: "GroomingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bath and Brush" },
                    { 2, "Haircut" },
                    { 3, "Nail Trim" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog Room" },
                    { 2, "Cat Room" },
                    { 3, "Bird Room" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Bird" },
                    { 4, "Horse" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "PetOwners",
                columns: new[] { "Id", "Age", "Email", "GenderId", "PetOwnerFirstName", "PetOwnerLastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, 30, "john@example.com", 1, "John", "Doe", "1234567890", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "AdoptionAnimals",
                columns: new[] { "Id", "Age", "AgentId", "City", "Description", "ImageUrl", "Name", "SpeciesId", "UserId" },
                values: new object[,]
                {
                    { 1, 3, 1, "Varna", "Friendly dog looking for a forever home.", "https://imgs.search.brave.com/6_mK4szCUhPtgYpWPnxvThzz8t1gjuxplafy-36PLLo/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTMw/MTgzOTExMi9waG90/by9wdXBweS13aXRo/LXRpbHRlZC1oZWFk/LWFuZC1jcm9zc2Vk/LXBhd3MtbHlpbmct/b24tc29mYS5qcGc_/cz02MTJ4NjEyJnc9/MCZrPTIwJmM9ak1x/TllGMXRPZGpIa2pP/QjZnTGdLbFc0V3I1/OGdzUWJIYnI4MnBK/Q0dpRT0", "Fluffy", 1, null },
                    { 2, 2, 1, "Sofia", "Playful cat in need of a loving family.", "https://imgs.search.brave.com/yUi94EMJUyOlxg2hDIkB884GABSL4Cy8XSt8L314Hqg/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/ZnJlZS1waG90by9w/b3J0cmFpdC1hZG9y/YWJsZS1kb21lc3Rp/Yy1jYXRfMjMtMjE0/OTE2NzA4OC5qcGc_/c2l6ZT02MjYmZXh0/PWpwZw", "Whiskers", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Groomers",
                columns: new[] { "Id", "Age", "AgentId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 23, 1, "Professional groomers providing high-quality grooming services.", "Kalina Yordanova" },
                    { 2, 30, 1, "Dedicated groomers offering personalized grooming sessions for your pets.", "Constantine Nenov" },
                    { 3, 27, 1, "Experienced groomers who love pampering your furry friends.", "Rosica Yordanova" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "City", "Description", "GenderId", "ImageUrl", "Name", "PetOwnerId", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 5, "Varna", "Friendly dog", 1, null, "Buddy", 1, 1 },
                    { 2, 3, "Sofia", "Playful cat", 2, null, "Whiskers", 1, 2 },
                    { 3, 2, "Burgas", "Talkative bird", 2, null, "Polly", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AgentId", "IsAvailable", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 1, true, 2 },
                    { 3, 1, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "GroomingReservations",
                columns: new[] { "Id", "EndTime", "GroomerId", "GroomingTypeId", "PetId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, new DateTime(2024, 4, 24, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, new DateTime(2024, 4, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RoomReservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "IncludesFood", "IncludesWalk", "RoomId", "RoomId1" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, null },
                    { 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAnimals_AgentId",
                table: "AdoptionAnimals",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAnimals_SpeciesId",
                table: "AdoptionAnimals",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionAnimals_UserId",
                table: "AdoptionAnimals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groomers_AgentId",
                table: "Groomers",
                column: "AgentId");

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
                name: "IX_PetOwners_GenderId",
                table: "PetOwners",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_UserId",
                table: "PetOwners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_GenderId",
                table: "Pets",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SpeciesId",
                table: "Pets",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_RoomId",
                table: "RoomReservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_RoomId1",
                table: "RoomReservations",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AgentId",
                table: "Rooms",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionAnimals");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GroomingReservations");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Groomers");

            migrationBuilder.DropTable(
                name: "GroomingTypes");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "PetOwners");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "GenderTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
