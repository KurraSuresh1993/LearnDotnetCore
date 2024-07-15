using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class tbluserupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "tbl_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "tbl_user",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "tbl_user",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "tbl_user");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tbl_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "tbl_user",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_user",
                newName: "userid");
        }
    }
}
