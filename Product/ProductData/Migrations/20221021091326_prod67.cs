using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductData.Migrations
{
    public partial class prod67 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colours",
                columns: table => new
                {
                    colourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    colourName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colourCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colours", x => x.colourId);
                });

            migrationBuilder.CreateTable(
                name: "creates",
                columns: table => new
                {
                    createId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creates", x => x.createId);
                });

            migrationBuilder.CreateTable(
                name: "sizescales",
                columns: table => new
                {
                    sizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sizeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizescales", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productYear = table.Column<int>(type: "int", nullable: false),
                    channelId = table.Column<int>(type: "int", nullable: false),
                    sizeScaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_products_sizescales_sizeScaleId",
                        column: x => x.sizeScaleId,
                        principalTable: "sizescales",
                        principalColumn: "sizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.articleId);
                    table.ForeignKey(
                        name: "FK_articles_colours_colourId",
                        column: x => x.colourId,
                        principalTable: "colours",
                        principalColumn: "colourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articles_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_colourId",
                table: "articles",
                column: "colourId");

            migrationBuilder.CreateIndex(
                name: "IX_articles_productId",
                table: "articles",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_products_sizeScaleId",
                table: "products",
                column: "sizeScaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "creates");

            migrationBuilder.DropTable(
                name: "colours");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "sizescales");
        }
    }
}
