using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductSold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_BranchId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Products_productID",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_Products_productID",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetails_productID",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_productID",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BranchId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "ProductsSold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    soldQuantity = table.Column<int>(type: "int", nullable: false),
                    SalesDetailId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Assignments_branchID",
                table: "Assignments",
                column: "branchID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSold_SalesDetailId",
                table: "ProductsSold",
                column: "SalesDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Branches_branchID",
                table: "Assignments",
                column: "branchID",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Branches_branchID",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "ProductsSold");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_branchID",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_productID",
                table: "SalesDetails",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_productID",
                table: "PurchaseDetails",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_BranchId",
                table: "Employees",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Products_productID",
                table: "PurchaseDetails",
                column: "productID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_Products_productID",
                table: "SalesDetails",
                column: "productID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
