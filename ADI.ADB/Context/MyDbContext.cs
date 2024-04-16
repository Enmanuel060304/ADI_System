using System;
using System.Collections.Generic;
using ADI.ADB.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesDetail> SalesDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ADI_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Category_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Id_LineNavigation).WithMany(p => p.Categories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Line_id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Customer_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Employee_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.rol).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Rol_Id");
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Line_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Product_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_id");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Purchase_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Employee).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchase_Employee_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchase_Supplier_id");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasOne(d => d.Id_ProductNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseDetails_Product_id");

            entity.HasOne(d => d.Id_PurchaseNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseDetails_Purchase_id");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Rol_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Sale_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Customer_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Employee_id");
        });

        modelBuilder.Entity<SalesDetail>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_SalesDetail_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.id_ProductNavigation).WithMany(p => p.SalesDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesDetail_Product_id");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Supplier_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
