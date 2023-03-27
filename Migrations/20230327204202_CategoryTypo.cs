using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoy",
                table: "Categories",
                newName: "CategoryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Categoy");
        }
    }
}
