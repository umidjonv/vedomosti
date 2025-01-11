using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vedy.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddDataForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsDeleted", "Login", "Password", "Role" },
                values: new object[,]
                {
                    { 1L, "Administrator", false, "admin", "4DA881DECEE92CA3B577F188EAAF92265A5550AF85F391CEB1FBE26A1C72F3E29AF139B1F941CDE4AA64C70CE01BACC3DE4F6F6657BF33CFCAA91EB27CB03EC4", 1 },
                    { 2L, "Operator", false, "operator", "990B065EF6ECA1303AF386821A61AB374CC412D7C482967086505ACA1295FBF8641DE8F3F0B020E4760A65F55AD7C898351626CDEDF5DAF5683D334B0DC68E2F", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
