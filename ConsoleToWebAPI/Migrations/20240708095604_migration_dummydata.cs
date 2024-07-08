using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleToWebAPI.Migrations
{
    public partial class migration_dummydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Description", "Email", "IsActive", "Name", "Salary" },
                values: new object[] { 1, "Senior Developer", "john.doe@example.com", true, "John Doe", 60000.0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Description", "Email", "IsActive", "Name", "Salary" },
                values: new object[] { 2, "Project Manager", "jane.smith@example.com", true, "Jane Smith", 80000.0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Description", "Email", "IsActive", "Name", "Salary" },
                values: new object[] { 3, "UX Designer", "alice.johnson@example.com", false, "Alice Johnson", 55000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
