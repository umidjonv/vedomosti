using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vedy.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEntries_Statements_SettlementId",
                table: "CustomerEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Statements_Users_UserId",
                table: "Statements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statements",
                table: "Statements");

            migrationBuilder.RenameTable(
                name: "Statements",
                newName: "Settlements");

            migrationBuilder.RenameIndex(
                name: "IX_Statements_UserId",
                table: "Settlements",
                newName: "IX_Settlements_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settlements",
                table: "Settlements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEntries_Settlements_SettlementId",
                table: "CustomerEntries",
                column: "SettlementId",
                principalTable: "Settlements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_UserId",
                table: "Settlements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEntries_Settlements_SettlementId",
                table: "CustomerEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_UserId",
                table: "Settlements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Settlements",
                table: "Settlements");

            migrationBuilder.RenameTable(
                name: "Settlements",
                newName: "Statements");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_UserId",
                table: "Statements",
                newName: "IX_Statements_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statements",
                table: "Statements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEntries_Statements_SettlementId",
                table: "CustomerEntries",
                column: "SettlementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statements_Users_UserId",
                table: "Statements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
