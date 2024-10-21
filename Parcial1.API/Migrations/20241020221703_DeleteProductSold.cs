using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1.API.Migrations
{
    /// <inheritdoc />
    public partial class DeleteProductSold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsSold");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsSold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesDetailId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    soldQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsSold_SalesDetails_SalesDetailId",
                        column: x => x.SalesDetailId,
                        principalTable: "SalesDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSold_SalesDetailId",
                table: "ProductsSold",
                column: "SalesDetailId");
        }
    }
}
