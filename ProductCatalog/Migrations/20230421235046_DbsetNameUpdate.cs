using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalog.Migrations
{
    public partial class DbsetNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_brands_CatalogBrandId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_catalogs_CatalogTypeId",
                table: "items");

            migrationBuilder.DropTable(
                name: "catalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "catalogItems");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "catalogBrands");

            migrationBuilder.RenameIndex(
                name: "IX_items_CatalogTypeId",
                table: "catalogItems",
                newName: "IX_catalogItems_CatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_items_CatalogBrandId",
                table: "catalogItems",
                newName: "IX_catalogItems_CatalogBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_catalogItems",
                table: "catalogItems",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_catalogBrands",
                table: "catalogBrands",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "catalogTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogType = table.Column<string>(type: "text", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogTypes", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_catalogItems_catalogBrands_CatalogBrandId",
                table: "catalogItems",
                column: "CatalogBrandId",
                principalTable: "catalogBrands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_catalogItems_catalogTypes_CatalogTypeId",
                table: "catalogItems",
                column: "CatalogTypeId",
                principalTable: "catalogTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogItems_catalogBrands_CatalogBrandId",
                table: "catalogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_catalogItems_catalogTypes_CatalogTypeId",
                table: "catalogItems");

            migrationBuilder.DropTable(
                name: "catalogTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_catalogItems",
                table: "catalogItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_catalogBrands",
                table: "catalogBrands");

            migrationBuilder.RenameTable(
                name: "catalogItems",
                newName: "items");

            migrationBuilder.RenameTable(
                name: "catalogBrands",
                newName: "brands");

            migrationBuilder.RenameIndex(
                name: "IX_catalogItems_CatalogTypeId",
                table: "items",
                newName: "IX_items_CatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_catalogItems_CatalogBrandId",
                table: "items",
                newName: "IX_items_CatalogBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "catalogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogType = table.Column<string>(type: "text", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogs", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_items_brands_CatalogBrandId",
                table: "items",
                column: "CatalogBrandId",
                principalTable: "brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_catalogs_CatalogTypeId",
                table: "items",
                column: "CatalogTypeId",
                principalTable: "catalogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
