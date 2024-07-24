using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class usermanagementtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "tbl_user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "tbl_user",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tbl_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbl_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "tbl_user",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tbl_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "tbl_user",
                newName: "username");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "tbl_user",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tbl_user",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "tbl_user",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "failattempt",
                table: "tbl_user",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "islocked",
                table: "tbl_user",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_menu",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_menu", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "tbl_otpManager",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    otptext = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    otptype = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    expiration = table.Column<DateTime>(type: "datetime", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_otpManager", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_pwdManger",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_pwdManger", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rolepermission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userrole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    menucode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    haveview = table.Column<bool>(type: "bit", nullable: false),
                    haveadd = table.Column<bool>(type: "bit", nullable: false),
                    haveedit = table.Column<bool>(type: "bit", nullable: false),
                    havedelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rolepermission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tempuser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tempuser", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_menu");

            migrationBuilder.DropTable(
                name: "tbl_otpManager");

            migrationBuilder.DropTable(
                name: "tbl_pwdManger");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_rolepermission");

            migrationBuilder.DropTable(
                name: "tbl_tempuser");

            migrationBuilder.DropColumn(
                name: "failattempt",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "islocked",
                table: "tbl_user");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "tbl_user",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "tbl_user",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "tbl_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tbl_user",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "tbl_user",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "tbl_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "tbl_user",
                newName: "Code");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "tbl_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbl_user",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tbl_user",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
