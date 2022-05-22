using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.API.Migrations
{
    public partial class colorAndImgChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_Color",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImgagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hex",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => new { x.ProductId, x.ColorName });
                    table.ForeignKey(
                        name: "FK_ProductColors_Colors_ColorName",
                        column: x => x.ColorName,
                        principalTable: "Colors",
                        principalColumn: "Color",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ColorName",
                table: "ProductColors",
                column: "ColorName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropColumn(
                name: "ImgagePath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Hex",
                table: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Color",
                table: "Products",
                column: "Color");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_Color",
                table: "Products",
                column: "Color",
                principalTable: "Colors",
                principalColumn: "Color",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
