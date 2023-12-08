using Dominio.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Context
{
    public class EnsuenoContext : DbContext
    {
        public EnsuenoContext() { }
        public EnsuenoContext(DbContextOptions<EnsuenoContext> options)
            :base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Ensueno"].ConnectionString,d => d.MigrationsAssembly("Persistencia"));
            }
            else
            {
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[])
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>{
                entity.HasKey(e => e.EmployeeId).HasName("Pk_EmployeeId_Employees");
                entity.Property(e => e.EmployeeName).HasMaxLength(50);
                entity.Property(e => e.EmployeeLastName).HasMaxLength(50);
                entity.Property(e => e.EmployeeIdentification).HasMaxLength(14);
                entity.Property(e => e.Image).HasColumnType("varbinary(max)");
                entity.HasIndex(e => e.EmployeeIdentification).IsUnique();
                entity.Property(e => e.EmployeePhone).HasMaxLength(8);
                entity.Property(e => e.EmployeeAddress).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");    
            });
            modelBuilder.Entity<Customers>(entity => {
                entity.HasKey(c => c.CustomerId).HasName("Pk_CustomerId_Customers");
                entity.Property(c => c.CustomerIdentification).HasMaxLength(14).IsUnicode(false);
                entity.HasIndex(c => c.CustomerIdentification).IsUnique();
                entity.Property(c => c.CustomerName).HasMaxLength(50);
                entity.Property(c => c.CustomerLastName).HasMaxLength(50);
                entity.Property(c => c.CustomerPhone).HasMaxLength(8);
                entity.Property(c => c.CustomerAddress).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.HasOne(c => c.EmployeesNavigation).WithMany(e => e.CustomersNavigation)
                .HasForeignKey(c => c.CreatedBy).HasConstraintName("Fk_CreatedBy_Customers");
                entity.Property(c => c.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.Property(c => c.IsActive).HasDefaultValue(true);
                entity.HasOne(c => c.EmployeesNavigation).WithMany(e => e.CustomersNavigation)
                .HasForeignKey(c => c.UpdateBy).HasConstraintName("Fk_UpdatedBy_Customers");
                entity.Property(c => c.Update_date_time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            });
            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(s => s.SupplierId).HasName("Pk_SupplierId_Suppliers");
                entity.Property(s => s.SupplierName).HasMaxLength(50);
                entity.Property(s => s.SupplierAddress).HasMaxLength(100);
                entity.Property(s => s.SupplierRUC).HasMaxLength(50);
                entity.HasIndex(s => s.SupplierRUC).IsUnique();
                entity.Property(s => s.SupplierPhone).HasMaxLength(8);
                entity.Property(s => s.SupplierEmail).HasMaxLength(50);
                entity.Property(s => s.IsActive).HasDefaultValue(true);
                entity.Property(s => s.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(s => s.Employee).WithMany(e => e.SuppliersNavigation)
                .HasForeignKey(s => s.CreatedBy).HasConstraintName("Fk_CreatedBy_Suppliers");
            });
            modelBuilder.Entity<Products>(entity => {
                entity.HasKey(p => p.ProdutId).HasName("Pk_ProductId_Products");
                entity.Property(p => p.ProductName).HasMaxLength(50);
                entity.Property(p => p.Image).HasColumnType("varbinary");
                entity.Property(p => p.Unit_Price).HasColumnType("decimal");
                entity.Property(p => p.IsActive).HasDefaultValue(true);
                entity.Property(p => p.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(p => p.Product_CategoryNavigation).WithMany(pc => pc.ProductNavigation)
                .HasForeignKey(p => p.ProductCategoryId).HasConstraintName("Fk_ProductCategoryId_Product");
                entity.HasIndex(p => p.ProductName).IsUnique();
                entity.HasOne(p => p.EmployeesNavigation).WithMany(e => e.ProductsCollections)
                .HasForeignKey(p => p.EmployeeId).HasConstraintName("Fk_EmployeeId_Products");
                entity.HasOne(p => p.EmployeesNavigation).WithMany(e => e.ProductsCollections)
                .HasForeignKey(p => p.UpdateBy).HasConstraintName("Fk_UpdatedBy_Products");
                entity.Property(p => p.Update_date_time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            });
            modelBuilder.Entity<Product_Category>(entity => {
                entity.HasKey(pc => pc.CategoryId).HasName("Pk_CategoryId_ProductCategory");
                entity.Property( pc => pc.CategoryName).HasMaxLength(50);
                entity.Property(pc => pc.IsActive).HasDefaultValue(true);
                entity.Property(pc => pc.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(pc => pc.EmployeeNavigation).WithMany(e => e.Product_CategoriesCollections)
                .HasForeignKey(pc => pc.CreatedBy).HasConstraintName("Fk_CreaatedBy_ProductCategory");
                entity.HasOne(pc => pc.EmployeeNavigation).WithMany(e => e.Product_CategoriesCollections)
                .HasForeignKey(pc => pc.UpdatedBy).HasConstraintName("Fk_UpdateBy_ProductCategory");
            });
            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(i => i.InvoiceId).IsClustered(true).HasName("Pk_InvoiceId_Invoices");
                entity.HasOne(i => i.EmployeesNavigation).WithMany(e => e.InvoiceCollectionsEmpl)
                .HasForeignKey(i => i.EmployeeId).HasConstraintName("Foreignk_EmployeeId_Invoices_2301").OnDelete(DeleteBehavior.ClientCascade);
                entity.HasOne(i => i.CustomersNavigation).WithMany(c => c.InvoicesCollections)
                .HasForeignKey(i => i.CustomerId).HasConstraintName("Foreignk_CustomerId_Invoices_2567").OnDelete(DeleteBehavior.ClientCascade);
                entity.Property(i => i.IsActive).HasDefaultValue(true);
                entity.Property(i => i.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            });
            modelBuilder.Entity<Invoice_Detail>(entity =>
            {
                entity.HasKey(id =>new { id.InvoiceId,id.ProductId }).IsClustered(true).HasName("Pk_InvoiceId_ProductId_InvoiceDetail");
                entity.Property(id => id.Price).HasColumnType("decimal");
                entity.HasOne(id => id.ProductsNavigation).WithMany(p => p.InvoiceDetailCollections)
                .HasForeignKey(id => id.ProductId).HasConstraintName("Fk_ProductId_InvoiceDetail");
                entity.HasOne(id => id.InvoicesNavigation).WithMany(i => i.InvoicesDetailsCollections)
                .HasForeignKey(id => id.InvoiceId).HasConstraintName("Fk_Invoice_InvoicesDetail");
            });
            modelBuilder.Entity<StockMovementType>(entity => {
                entity.HasKey(sm => sm.MovementId).HasName("Pk_MovementId");
                entity.Property(sm => sm.Type).HasMaxLength(50);
            });
            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.HasKey(sm => sm.MovementId).HasName("Pk_SupplierId_ProductId_StockMovements");
                entity.HasOne(sm => sm.ProductsNavigation).WithMany(p => p.StockMovementsCollections)
                .HasForeignKey(sm => sm.ProductId).HasConstraintName("Fk_ProductId_StockMovements").OnDelete(DeleteBehavior.ClientCascade);
                entity.HasOne(sm => sm.SuppliersNavigation).WithMany(s => s.StockMovementsCollections)
                .HasForeignKey(sm => sm.SupplierId).HasConstraintName("Pk_SupplierId_StockMovements").OnDelete(DeleteBehavior.ClientCascade);
                entity.HasOne(sm => sm.StockMovementTypeNavigation).WithMany(smt => smt.StockMovementCollections)
                .HasForeignKey(sm => sm.TypeStockMovement).HasConstraintName("Fk_MovementId_StockMovement").OnDelete(DeleteBehavior.ClientCascade);
                entity.Property(sm => sm.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(sm => sm.InvoicesNavigation).WithMany(i => i.StockMovementsColletions)
                .HasForeignKey(sm => sm.InvoiceId).HasConstraintName("Fk_InvoiceId_StockMovements");
            });
            modelBuilder.Entity<Users>(entity => {
                entity.HasKey(u => u.UserId).HasName("Pk_UserId_User");
                entity.HasOne(u => u.EmployeesNavigation).WithMany(e => e.UserCollections)
                .HasForeignKey(u => u.EmployeeId).HasConstraintName("Fk_EmployeeId_Users");
                entity.Property(u => u.UserName).HasMaxLength(20);
                entity.HasIndex(u => u.UserName).IsUnique();
                entity.Property(u => u.IsActive).HasDefaultValue(true);
                entity.Property(u => u.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(u => u.EmployeesNavigation).WithMany(e => e.UserCollections)
                .HasForeignKey(u => u.UpdateBy).HasConstraintName("Fk_UpdatedBy_Users");
            });
            modelBuilder.Entity<Sessions>(entity => {
                entity.HasKey(se => se.SesionId).HasName("Pk_SessionId_Sessions");
                entity.Property(se => se.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(se => se.UsersNavigation).WithMany(u => u.SessionsCollection)
                .HasForeignKey(se => se.UserId).HasConstraintName("Fk_UserId_Sessions");
            });
            modelBuilder.Entity<Rol>(entity => {
                entity.HasKey(r => r.RolId).HasName("Pk_RolId_Rol");
                entity.Property(r => r.RolName).HasMaxLength(20);
                entity.HasOne(r => r.EmployeeNavigation).WithMany(e => e.RolCollections)
                .HasForeignKey(r => r.EmployeeId).HasConstraintName("Fk_EmployeeId_Rol");
                entity.HasOne(r => r.EmployeeNavigation).WithMany(e => e.RolCollections)
                .HasForeignKey(r =>  r.CreatedBy).HasConstraintName("Fk_CreatedBy_Rol");
                entity.HasOne(r => r.EmployeeNavigation).WithMany(e => e.RolCollections)
                .HasForeignKey(r => r.UpdatedBy).HasConstraintName("Fk_UpdateBy_Rol");
                entity.Property(r => r.IsActive).HasDefaultValue(true);
                entity.Property(r => r.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            });
            modelBuilder.Entity<Formularios>(entity => {
                entity.HasKey(p => p.FormId).HasName("Pk_PermissionsId_Permissions");
                entity.Property(p => p.Name).HasMaxLength(20);
                entity.HasOne(p => p.EmployeeNavigation).WithMany(e => e.FormsCollections)
                .HasForeignKey(p => p.UpdatedBy).HasConstraintName("Pk_EmployeId_Permissions");
            });
            modelBuilder.Entity<Procedures>(entity => {
                entity.HasKey(p => p.ProcedureId).HasName("Pk_ProcedureId_Procedures");
                entity.Property(p => p.ProcedureName).HasMaxLength(10);
            });
            modelBuilder.Entity<ProcedureRols>(entity => {
                entity.HasKey(pr => pr.ProceduresRolsId).HasName("Pk_ProcedureId_ProcedureRols");
                entity.HasOne(pr => pr.ProcedureNavigation).WithMany(p => p.ProceduresRolsCollections)
                .HasForeignKey(pr => pr.ProcedureId).HasConstraintName("fk_procedureId_ProcedureRols");
                entity.HasOne(pr => pr.RolNavigation).WithMany(r => r.ProceduresRolsCollections)
                .HasForeignKey(pr => pr.RolId).HasConstraintName("Fk_RolId_procedureRols");
                entity.Property(pr => pr.IsActive).HasDefaultValue(true);
                entity.Property(pr => pr.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            });
            modelBuilder.Entity<FormRol>(entity => {
                entity.HasKey(pr => pr.RolId).HasName("PK_PermissionsRol_PermissionsRol");
                entity.HasOne(pr => pr.RolNavigation).WithMany(r => r.FormRolCollections)
                .HasForeignKey(pr => pr.RolId).HasConstraintName("Fk_RolId_PermissionsRolId").OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(pr => pr.FormsNavigation).WithMany(p => p.FormRolCollections)
                .HasForeignKey(pr => pr.PermissionsId).HasConstraintName("Fk_PermissionsId_PermissionsRolId").OnDelete(DeleteBehavior.NoAction);
                entity.Property(pr => pr.IsActive).HasDefaultValue(true);
                entity.Property(pr => pr.Date_Time).HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
                entity.HasOne(pr => pr.EmployeeNavigation).WithMany(e => e.FormRolCollectios)
                .HasForeignKey(pr =>  pr.CreatedBy ).HasConstraintName("FkCreatedBy_FormRol");
                entity.HasOne(pr => pr.EmployeeNavigation).WithMany(e => e.FormRolCollectios)
                .HasForeignKey(pr => pr.UpdatedBy).HasConstraintName("Fk_UpdateBy_FormRol");
            });
            modelBuilder.Entity<UsersRol>(entity => {
                entity.HasKey(e => e.Id).HasName("PK_Id_UserRol");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.HasOne(e => e.UsersNavigation).WithMany(e => e.UserRolCollections)
                .HasForeignKey(e => e.IdUser).HasConstraintName("FK_IDUSER_UsersRol").OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(u => u.RolNavigation).WithMany(r => r.UserRolCollections)
                .HasForeignKey(u => u.IdRol).HasConstraintName("Pk_RolId_Users").OnDelete(DeleteBehavior.NoAction);
            });
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Invoice_Detail> Invoices_Detail { get; set;}
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<StockMovementType> StockMovementTypes { get; set; }
        public virtual DbSet<StockMovement> StockMovement { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Formularios> Forms { get; set; }
        public virtual DbSet<FormRol> FormRols { get; set; }
        public virtual DbSet<Procedures> Procedures { get; set; }
        public virtual DbSet<ProcedureRols> ProcedureRols { get; set; }

    }
}
