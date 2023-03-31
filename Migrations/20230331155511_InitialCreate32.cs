using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBiteBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/DutchCheesePlate.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/StroopWaffelSundae.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Bitterballen.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/nasiGoren.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SataySkewer.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/gadoGadoSalad.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/MargaritaPizza.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpagettiCarbonora.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Tiramisu.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/ClassicBurger.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/VeggieBurger.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/SpanisTortilla.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/PaellaValencia.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14,
                column: "PictureUrl",
                value: "https://quickbitestorage.blob.core.windows.net/quickbitecontainer/Gazpacho.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13,
                column: "PictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14,
                column: "PictureUrl",
                value: "");
        }
    }
}
