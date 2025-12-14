using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagerApp.DAL.Models
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table_accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, name: "id"),
                    Login = table.Column<string>(type: "text", nullable: false, name: "login"),
                    Password = table.Column<string>(type: "text", nullable: false, name: "password"),
                    Description = table.Column<string>(type: "text", nullable: true, name: "description"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, name: "is_active", defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "table_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, name: "id"),
                    LastName = table.Column<string>(type: "text", nullable: false, name: "last_name"),
                    FirstName = table.Column<string>(type: "text", nullable: false, name: "first_name"),
                    Email = table.Column<string>(type: "text", nullable: false, name: "email"),
                    PhoneNumbers = table.Column<string[]>(type: "text[]", nullable: false, name: "phone_numbers"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, name: "is_active", defaultValue: true),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false, name: "account_id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "table_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "table_users",
                column: "account_id",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Login",
                table: "table_accounts",
                column: "login",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "table_users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_users");

            migrationBuilder.DropTable(
                name: "table_accounts");
        }
    }
}
