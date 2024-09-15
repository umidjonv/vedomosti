using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vedy.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SettlementCompanyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Settlements",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_CompanyId",
                table: "Settlements",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Companies_CompanyId",
                table: "Settlements",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Companies_CompanyId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_CompanyId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Settlements");
        }
    }
}
