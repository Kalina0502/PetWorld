using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetWorld.Infrastructure.Migrations
{
    public partial class TablesModifiedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36823253-4c96-46f0-ae97-3301b14cf418", "AQAAAAEAACcQAAAAEDm+BFyHWHlHy0+jFOGUXuC01h6fqc3QtRG1U3Pm37kxeamrIzLmY9RKwKr/31zINg==", "dfdf9ecd-eeb1-4799-b292-7067dd383b6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5950cb9b-1d6f-4fb7-997b-29caf3d74c12", "AQAAAAEAACcQAAAAEIbavKDUdVNCz2TBxYz8CyKAsOxuBQ/OrpeFkkyq8+JwcTGin1QzotK5ivAqGlX3JA==", "3c05915e-2524-40ba-a3e4-a7f2233f6377" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eb1c236-07de-4a54-8377-6c24c7345303", "AQAAAAEAACcQAAAAEO+FqYD1N347l01k6lkytwOQISLdACxw9fhoQtbPOm/w20npL/oKa9G5gVWEXCQnfg==", "e2d6ca3e-16fc-45fa-8276-956dd2fadd4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2311f5a-fb4f-4206-9efb-50e984962e45", "AQAAAAEAACcQAAAAEKDE+rIkD4EgFcZmLT+e6PDBMw4akBxEMZZf4ncJ+6DoTyJ5gnsXIWcxqEmhF8ldvA==", "498b5b6c-2476-47df-9d90-a5d722e87a6a" });
        }
    }
}
