using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeIdentification = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_EmployeeId_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_CategoryId_ProductCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "StockMovementTypes",
                columns: table => new
                {
                    MovementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_MovementId", x => x.MovementId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerIdentification = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Update_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_CustomerId_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "Fk_UpdatedBy_Customers",
                        column: x => x.UpdateBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionsName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_PermissionsId_Permissions", x => x.PermissionsId);
                    table.ForeignKey(
                        name: "Pk_EmployeId_Permissions",
                        column: x => x.EmployeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_RolId_Rol", x => x.RolId);
                    table.ForeignKey(
                        name: "Fk_EmployeeId_Rol",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupplierRUC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierPhone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SupplierEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_SupplierId_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "Fk_CreatedBy_Suppliers",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProdutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Unit_Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Update_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_ProductId_Products", x => x.ProdutId);
                    table.ForeignKey(
                        name: "Fk_ProductCategoryId_Product",
                        column: x => x.ProductCategoryId,
                        principalTable: "Product_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_UpdatedBy_Products",
                        column: x => x.UpdateBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_InvoiceId_Invoices", x => x.InvoiceId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "Foreignk_CustomerId_Invoices_2567",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "Foreignk_EmployeeId_Invoices_2301",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "PermissionsRols",
                columns: table => new
                {
                    PermissionsRolId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsRol_PermissionsRol", x => new { x.PermissionsRolId, x.PermissionsId, x.RolId });
                    table.ForeignKey(
                        name: "Fk_PermissionsId_PermissionsRolId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionsId");
                    table.ForeignKey(
                        name: "Fk_RolId_PermissionsRolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "RolId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Update_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_UserId_User", x => x.UserId);
                    table.ForeignKey(
                        name: "Fk_UpdatedBy_Users",
                        column: x => x.UpdateBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Pk_RolId_Users",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "RolId");
                });

            migrationBuilder.CreateTable(
                name: "StockMovement",
                columns: table => new
                {
                    MovementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TypeStockMovement = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_SupplierId_ProductId_StockMovements", x => x.MovementId);
                    table.ForeignKey(
                        name: "Fk_MovementId_StockMovement",
                        column: x => x.TypeStockMovement,
                        principalTable: "StockMovementTypes",
                        principalColumn: "MovementId");
                    table.ForeignKey(
                        name: "Fk_ProductId_StockMovements",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProdutId");
                    table.ForeignKey(
                        name: "Pk_SupplierId_StockMovements",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Invoices_Detail",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_InvoiceId_ProductId_InvoiceDetail", x => new { x.InvoiceId, x.ProductId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "Fk_Invoice_InvoicesDetail",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_ProductId_InvoiceDetail",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProdutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_SessionId_Sessions", x => x.SesionId);
                    table.ForeignKey(
                        name: "Fk_UserId_Sessions",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerIdentification",
                table: "Customers",
                column: "CustomerIdentification",
                unique: true,
                filter: "[CustomerIdentification] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UpdateBy",
                table: "Customers",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeIdentification",
                table: "Employees",
                column: "EmployeeIdentification",
                unique: true,
                filter: "[EmployeeIdentification] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeId",
                table: "Invoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Detail_ProductId",
                table: "Invoices_Detail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeId",
                table: "Permissions",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsRols_PermissionsId",
                table: "PermissionsRols",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsRols_RolId",
                table: "PermissionsRols",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName",
                unique: true,
                filter: "[ProductName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdateBy",
                table: "Products",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rols_EmployeeId",
                table: "Rols",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_ProductId",
                table: "StockMovement",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_SupplierId",
                table: "StockMovement",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_TypeStockMovement",
                table: "StockMovement",
                column: "TypeStockMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatedBy",
                table: "Suppliers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierRUC",
                table: "Suppliers",
                column: "SupplierRUC",
                unique: true,
                filter: "[SupplierRUC] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdateBy",
                table: "Users",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices_Detail");

            migrationBuilder.DropTable(
                name: "PermissionsRols");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "StockMovement");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StockMovementTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Product_Category");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
