using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.API.Migrations
{
    public partial class helloDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Product_ProductId",
                table: "ProductTag");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_ProductId",
                table: "ProductTag",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_ProductId",
                table: "ProductTag");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandEntityBrandId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryEntityCategory = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorEntityColor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeEntitySize = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Brands_BrandEntityBrandId",
                        column: x => x.BrandEntityBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryEntityCategory",
                        column: x => x.CategoryEntityCategory,
                        principalTable: "Categories",
                        principalColumn: "Category");
                    table.ForeignKey(
                        name: "FK_Product_Colors_ColorEntityColor",
                        column: x => x.ColorEntityColor,
                        principalTable: "Colors",
                        principalColumn: "Color");
                    table.ForeignKey(
                        name: "FK_Product_Sizes_SizeEntitySize",
                        column: x => x.SizeEntitySize,
                        principalTable: "Sizes",
                        principalColumn: "Size");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandEntityBrandId",
                table: "Product",
                column: "BrandEntityBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryEntityCategory",
                table: "Product",
                column: "CategoryEntityCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ColorEntityColor",
                table: "Product",
                column: "ColorEntityColor");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeEntitySize",
                table: "Product",
                column: "SizeEntitySize");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Product_ProductId",
                table: "ProductTag",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
