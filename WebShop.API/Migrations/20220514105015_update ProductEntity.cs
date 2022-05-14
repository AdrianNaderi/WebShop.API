using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.API.Migrations
{
    public partial class updateProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandEntityBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryEntityCategory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorEntityColor",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sizes_SizeEntitySize",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandEntityBrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryEntityCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorEntityColor",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SizeEntitySize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandEntityBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryEntityCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorEntityColor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SizeEntitySize",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category",
                table: "Products",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Color",
                table: "Products",
                column: "Color");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Size",
                table: "Products",
                column: "Size");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Category",
                table: "Products",
                column: "Category",
                principalTable: "Categories",
                principalColumn: "Category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_Color",
                table: "Products",
                column: "Color",
                principalTable: "Colors",
                principalColumn: "Color",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sizes_Size",
                table: "Products",
                column: "Size",
                principalTable: "Sizes",
                principalColumn: "Size",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Category",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_Color",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sizes_Size",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Category",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Color",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Size",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BrandEntityBrandId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryEntityCategory",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorEntityColor",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeEntitySize",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandEntityBrandId",
                table: "Products",
                column: "BrandEntityBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryEntityCategory",
                table: "Products",
                column: "CategoryEntityCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorEntityColor",
                table: "Products",
                column: "ColorEntityColor");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeEntitySize",
                table: "Products",
                column: "SizeEntitySize");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandEntityBrandId",
                table: "Products",
                column: "BrandEntityBrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryEntityCategory",
                table: "Products",
                column: "CategoryEntityCategory",
                principalTable: "Categories",
                principalColumn: "Category");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorEntityColor",
                table: "Products",
                column: "ColorEntityColor",
                principalTable: "Colors",
                principalColumn: "Color");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sizes_SizeEntitySize",
                table: "Products",
                column: "SizeEntitySize",
                principalTable: "Sizes",
                principalColumn: "Size",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
