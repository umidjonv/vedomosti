using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vedy.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class NewCompanyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Customers_CustomerId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CustomerId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customers");

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CustomerId",
                table: "Companies",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Customers_CustomerId",
                table: "Companies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
