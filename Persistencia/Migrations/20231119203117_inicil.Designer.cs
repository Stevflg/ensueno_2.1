﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Context;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(EnsuenoContext))]
    [Migration("20231119203117_inicil")]
    partial class inicil
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Database.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerIdentification")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("CustomerId")
                        .HasName("Pk_CustomerId_Customers");

                    b.HasIndex("CustomerIdentification")
                        .IsUnique();

                    b.HasIndex("UpdateBy");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Dominio.Database.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeIdentification")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("EmployeeLastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeePhone")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId")
                        .HasName("Pk_EmployeeId_Employees");

                    b.HasIndex("EmployeeIdentification")
                        .IsUnique()
                        .HasFilter("[EmployeeIdentification] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Dominio.Database.FormRol", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FormRolId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("RolId")
                        .HasName("PK_PermissionsRol_PermissionsRol");

                    b.HasIndex("PermissionsId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("FormRols");
                });

            modelBuilder.Entity("Dominio.Database.Formularios", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormId"));

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("FormId")
                        .HasName("Pk_PermissionsId_Permissions");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Dominio.Database.Invoice_Detail", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId", "ProductId")
                        .HasName("Pk_InvoiceId_ProductId_InvoiceDetail");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("InvoiceId", "ProductId"));

                    b.HasIndex("ProductId");

                    b.ToTable("Invoices_Detail");
                });

            modelBuilder.Entity("Dominio.Database.Invoices", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("InvoiceId")
                        .HasName("Pk_InvoiceId_Invoices");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("InvoiceId"));

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Dominio.Database.ProcedureRols", b =>
                {
                    b.Property<int>("ProceduresRolsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProceduresRolsId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeNavigationEmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("ProceduresRolsId")
                        .HasName("Pk_ProcedureId_ProcedureRols");

                    b.HasIndex("EmployeeNavigationEmployeeId");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("RolId");

                    b.ToTable("ProcedureRols");
                });

            modelBuilder.Entity("Dominio.Database.Procedures", b =>
                {
                    b.Property<int>("ProcedureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcedureId"));

                    b.Property<string>("ProcedureName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProcedureId")
                        .HasName("Pk_ProcedureId_Procedures");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("Dominio.Database.Product_Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("CategoryId")
                        .HasName("Pk_CategoryId_ProductCategory");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Product_Category");
                });

            modelBuilder.Entity("Dominio.Database.Products", b =>
                {
                    b.Property<int>("ProdutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutId"));

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Unit_Price")
                        .HasColumnType("decimal");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update_date_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("ProdutId")
                        .HasName("Pk_ProductId_Products");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductName")
                        .IsUnique();

                    b.HasIndex("UpdateBy");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Dominio.Database.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("RolName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("RolId")
                        .HasName("Pk_RolId_Rol");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("Dominio.Database.Sessions", b =>
                {
                    b.Property<int>("SesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SesionId"));

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SesionId")
                        .HasName("Pk_SessionId_Sessions");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Dominio.Database.StockMovement", b =>
                {
                    b.Property<int>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovementId"));

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("TypeStockMovement")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("MovementId")
                        .HasName("Pk_SupplierId_ProductId_StockMovements");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TypeStockMovement");

                    b.ToTable("StockMovement");
                });

            modelBuilder.Entity("Dominio.Database.StockMovementType", b =>
                {
                    b.Property<int>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovementId"));

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MovementId")
                        .HasName("Pk_MovementId");

                    b.ToTable("StockMovementTypes");
                });

            modelBuilder.Entity("Dominio.Database.Suppliers", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("SupplierAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SupplierEmail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupplierName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupplierPhone")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("SupplierRUC")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.HasKey("SupplierId")
                        .HasName("Pk_SupplierId_Suppliers");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SupplierRUC")
                        .IsUnique()
                        .HasFilter("[SupplierRUC] IS NOT NULL");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Dominio.Database.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update_date_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId")
                        .HasName("Pk_UserId_User");

                    b.HasIndex("RolId");

                    b.HasIndex("UpdateBy");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dominio.Database.Customers", b =>
                {
                    b.HasOne("Dominio.Database.Employees", "EmployeesNavigation")
                        .WithMany("CustomersNavigation")
                        .HasForeignKey("UpdateBy")
                        .HasConstraintName("Fk_UpdatedBy_Customers");

                    b.Navigation("EmployeesNavigation");
                });

            modelBuilder.Entity("Dominio.Database.FormRol", b =>
                {
                    b.HasOne("Dominio.Database.Formularios", "FormsNavigation")
                        .WithMany("FormRolCollections")
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_PermissionsId_PermissionsRolId");

                    b.HasOne("Dominio.Database.Rol", "RolNavigation")
                        .WithMany("FormRolCollections")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_RolId_PermissionsRolId");

                    b.HasOne("Dominio.Database.Employees", "EmployeeNavigation")
                        .WithMany("FormRolCollectios")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("Fk_UpdateBy_FormRol");

                    b.Navigation("EmployeeNavigation");

                    b.Navigation("FormsNavigation");

                    b.Navigation("RolNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Formularios", b =>
                {
                    b.HasOne("Dominio.Database.Employees", "EmployeeNavigation")
                        .WithMany("FormsCollections")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("Pk_EmployeId_Permissions");

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Invoice_Detail", b =>
                {
                    b.HasOne("Dominio.Database.Invoices", "InvoicesNavigation")
                        .WithMany("InvoicesDetailsCollections")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_Invoice_InvoicesDetail");

                    b.HasOne("Dominio.Database.Products", "ProductsNavigation")
                        .WithMany("InvoiceDetailCollections")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ProductId_InvoiceDetail");

                    b.Navigation("InvoicesNavigation");

                    b.Navigation("ProductsNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Invoices", b =>
                {
                    b.HasOne("Dominio.Database.Customers", "CustomersNavigation")
                        .WithMany("InvoicesCollections")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("Foreignk_CustomerId_Invoices_2567");

                    b.HasOne("Dominio.Database.Employees", "EmployeesNavigation")
                        .WithMany("InvoiceCollectionsEmpl")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("Foreignk_EmployeeId_Invoices_2301");

                    b.Navigation("CustomersNavigation");

                    b.Navigation("EmployeesNavigation");
                });

            modelBuilder.Entity("Dominio.Database.ProcedureRols", b =>
                {
                    b.HasOne("Dominio.Database.Employees", "EmployeeNavigation")
                        .WithMany("ProcedureRolCollections")
                        .HasForeignKey("EmployeeNavigationEmployeeId");

                    b.HasOne("Dominio.Database.Procedures", "ProcedureNavigation")
                        .WithMany("ProceduresRolsCollections")
                        .HasForeignKey("ProcedureId")
                        .HasConstraintName("fk_procedureId_ProcedureRols");

                    b.HasOne("Dominio.Database.Rol", "RolNavigation")
                        .WithMany("ProceduresRolsCollections")
                        .HasForeignKey("RolId")
                        .HasConstraintName("Fk_RolId_procedureRols");

                    b.Navigation("EmployeeNavigation");

                    b.Navigation("ProcedureNavigation");

                    b.Navigation("RolNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Product_Category", b =>
                {
                    b.HasOne("Dominio.Database.Employees", "EmployeeNavigation")
                        .WithMany("Product_CategoriesCollections")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("Fk_UpdateBy_ProductCategory");

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Products", b =>
                {
                    b.HasOne("Dominio.Database.Product_Category", "Product_CategoryNavigation")
                        .WithMany("ProductNavigation")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ProductCategoryId_Product");

                    b.HasOne("Dominio.Database.Employees", "EmployeesNavigation")
                        .WithMany("ProductsCollections")
                        .HasForeignKey("UpdateBy")
                        .HasConstraintName("Fk_UpdatedBy_Products");

                    b.Navigation("EmployeesNavigation");

                    b.Navigation("Product_CategoryNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Rol", b =>
                {
                    b.HasOne("Dominio.Database.Employees", "EmployeeNavigation")
                        .WithMany("RolCollections")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("Fk_UpdateBy_Rol");

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Sessions", b =>
                {
                    b.HasOne("Dominio.Database.Users", "UsersNavigation")
                        .WithMany("SessionsCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_UserId_Sessions");

                    b.Navigation("UsersNavigation");
                });

            modelBuilder.Entity("Dominio.Database.StockMovement", b =>
                {
                    b.HasOne("Dominio.Database.Products", "ProductsNavigation")
                        .WithMany("StockMovementsCollections")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ProductId_StockMovements");

                    b.HasOne("Dominio.Database.Suppliers", "SuppliersNavigation")
                        .WithMany("StockMovementsCollections")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("Pk_SupplierId_StockMovements");

                    b.HasOne("Dominio.Database.StockMovementType", "StockMovementTypeNavigation")
                        .WithMany("StockMovementCollections")
                        .HasForeignKey("TypeStockMovement")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("Fk_MovementId_StockMovement");

                    b.Navigation("ProductsNavigation");

                    b.Navigation("StockMovementTypeNavigation");

                    b.Navigation("SuppliersNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Suppliers", b =>
                {
                    b.HasOne("Dominio.Database.Employees", "Employee")
                        .WithMany("SuppliersNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("Fk_CreatedBy_Suppliers");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Dominio.Database.Users", b =>
                {
                    b.HasOne("Dominio.Database.Rol", "RolNavigation")
                        .WithMany("UserCollections")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Pk_RolId_Users");

                    b.HasOne("Dominio.Database.Employees", "EmployeesNavigation")
                        .WithMany("UserCollections")
                        .HasForeignKey("UpdateBy")
                        .HasConstraintName("Fk_UpdatedBy_Users");

                    b.Navigation("EmployeesNavigation");

                    b.Navigation("RolNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Customers", b =>
                {
                    b.Navigation("InvoicesCollections");
                });

            modelBuilder.Entity("Dominio.Database.Employees", b =>
                {
                    b.Navigation("CustomersNavigation");

                    b.Navigation("FormRolCollectios");

                    b.Navigation("FormsCollections");

                    b.Navigation("InvoiceCollectionsEmpl");

                    b.Navigation("ProcedureRolCollections");

                    b.Navigation("Product_CategoriesCollections");

                    b.Navigation("ProductsCollections");

                    b.Navigation("RolCollections");

                    b.Navigation("SuppliersNavigation");

                    b.Navigation("UserCollections");
                });

            modelBuilder.Entity("Dominio.Database.Formularios", b =>
                {
                    b.Navigation("FormRolCollections");
                });

            modelBuilder.Entity("Dominio.Database.Invoices", b =>
                {
                    b.Navigation("InvoicesDetailsCollections");
                });

            modelBuilder.Entity("Dominio.Database.Procedures", b =>
                {
                    b.Navigation("ProceduresRolsCollections");
                });

            modelBuilder.Entity("Dominio.Database.Product_Category", b =>
                {
                    b.Navigation("ProductNavigation");
                });

            modelBuilder.Entity("Dominio.Database.Products", b =>
                {
                    b.Navigation("InvoiceDetailCollections");

                    b.Navigation("StockMovementsCollections");
                });

            modelBuilder.Entity("Dominio.Database.Rol", b =>
                {
                    b.Navigation("FormRolCollections");

                    b.Navigation("ProceduresRolsCollections");

                    b.Navigation("UserCollections");
                });

            modelBuilder.Entity("Dominio.Database.StockMovementType", b =>
                {
                    b.Navigation("StockMovementCollections");
                });

            modelBuilder.Entity("Dominio.Database.Suppliers", b =>
                {
                    b.Navigation("StockMovementsCollections");
                });

            modelBuilder.Entity("Dominio.Database.Users", b =>
                {
                    b.Navigation("SessionsCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
