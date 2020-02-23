using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSample.Migrations
{
    public partial class updateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "uc");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "uc");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "uc");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "uc",
                table: "User",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "User",
                schema: "uc",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "uc",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "uc",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "uc",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "uc",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "uc",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "uc",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "uc",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "uc",
                newName: "AspNetRoleClaims");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
