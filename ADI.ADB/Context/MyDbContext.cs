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

    public virtual DbSet<Categorias> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVentas> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<ventas> venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ADI_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Categoria_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Id_LineaNavigation).WithMany(p => p.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Linea_id");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Customer_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Compra_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Empleado_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Proveedor_id");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_DetalleCompra_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Compra_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Producto_id");
        });

        modelBuilder.Entity<DetalleVentas>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_DetalleVenta_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVenta_Producto_id");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVenta_Venta_id");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Employee_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.rol).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Rol_Id");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Linea_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Producto_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categoria_id");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Proveedor_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Rol_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ventas>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Venta_id");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Cliente).WithMany(p => p.venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Cliente_id");

            entity.HasOne(d => d.Empleado).WithMany(p => p.venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Empleado_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
