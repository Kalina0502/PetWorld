using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class GenderTypeModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9862be33-982e-4256-bf01-2f083c9fadfb", "AQAAAAEAACcQAAAAEEAEMlWwOC7zyACKXC+GLxaFn+i46KsbyOWXyubmkIt2nsTaaSH3XMKYdfhAaRpMNQ==", "3c2615fd-fb57-4da9-bf7f-012bc18654cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1d93a5a-ec49-45e8-bf9b-8c6389b8b8b2", "AQAAAAEAACcQAAAAEOMy0aG7+tlMT1IR5ggdC7ZGiHWy4eZRAvheWZf/HvYr1u7VbUFHocokJ3jGi3If2g==", "a86b3964-0f60-4047-87ff-ea0e1acc14f1" });
        }
    }
}
