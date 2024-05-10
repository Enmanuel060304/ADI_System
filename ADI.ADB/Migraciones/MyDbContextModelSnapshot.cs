﻿// <auto-generated />
using System;
using ADI.ADB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ADI.ADB.Migraciones
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ADI.ADB.modelos.Categoria", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id")
                        .HasName("PK_Categoria_id");

                    b.HasIndex(new[] { "Nombre" }, "IX_Categoria_Nombre")
                        .IsUnique();

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Cliente", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id")
                        .HasName("PK_Customer_id");

                    b.HasIndex(new[] { "Nombre", "Apellido", "Telefono", "Email" }, "IX_Cliente_Nombre")
                        .IsUnique()
                        .HasFilter("[Nombre] IS NOT NULL AND [Apellido] IS NOT NULL AND [Telefono] IS NOT NULL AND [Email] IS NOT NULL");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Compra", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("Empleado_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Fecha")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Proveedor_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalDescuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalFacturado")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("id")
                        .HasName("PK_Compra_id");

                    b.HasIndex("Empleado_id");

                    b.HasIndex("Proveedor_id");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("ADI.ADB.modelos.DetalleCompra", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("Compra_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("Producto_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id")
                        .HasName("PK_DetalleCompra_id");

                    b.HasIndex("Compra_id");

                    b.HasIndex("Producto_id");

                    b.ToTable("DetalleCompra");
                });

            modelBuilder.Entity("ADI.ADB.modelos.DetalleVenta", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("Producto_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Venta_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id")
                        .HasName("PK_DetalleVenta_id");

                    b.HasIndex("Producto_id");

                    b.HasIndex("Venta_id");

                    b.ToTable("DetalleVenta");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Empleado", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("rol_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id")
                        .HasName("PK_Employee_id");

                    b.HasIndex("rol_id");

                    b.HasIndex(new[] { "Nombre", "Apellido", "Telefono", "email" }, "IX_Empleado_Nombre")
                        .IsUnique();

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Linea", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id")
                        .HasName("PK_Linea_id");

                    b.HasIndex(new[] { "Nombre" }, "IX_Linea_Nombre")
                        .IsUnique();

                    b.ToTable("Linea");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Producto", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("Categoria_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Linea_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("id")
                        .HasName("PK_Producto_id");

                    b.HasIndex("Categoria_id");

                    b.HasIndex("Linea_id");

                    b.HasIndex(new[] { "Nombre" }, "IX_Producto_Nombre")
                        .IsUnique();

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Proveedor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id")
                        .HasName("PK_Proveedor_id");

                    b.HasIndex(new[] { "Nombre", "Apellido", "Telefono", "Email" }, "IX_Proveedor_name")
                        .IsUnique();

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Rol", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id")
                        .HasName("PK_Rol_id");

                    b.HasIndex(new[] { "Nombre" }, "IX_Rol_Nombre")
                        .IsUnique();

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("ADI.ADB.modelos.venta", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("Cliente_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Empleado_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Fecha")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("TotalDescuento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalFacturado")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("id")
                        .HasName("PK_Venta_id");

                    b.HasIndex("Cliente_id");

                    b.HasIndex("Empleado_id");

                    b.ToTable("venta");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Compra", b =>
                {
                    b.HasOne("ADI.ADB.modelos.Empleado", "Empleado")
                        .WithMany("Compras")
                        .HasForeignKey("Empleado_id")
                        .IsRequired()
                        .HasConstraintName("FK_Compra_Empleado_id");

                    b.HasOne("ADI.ADB.modelos.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("Proveedor_id")
                        .IsRequired()
                        .HasConstraintName("FK_Compra_Proveedor_id");

                    b.Navigation("Empleado");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ADI.ADB.modelos.DetalleCompra", b =>
                {
                    b.HasOne("ADI.ADB.modelos.Compra", "Compra")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("Compra_id")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleCompra_Compra_id");

                    b.HasOne("ADI.ADB.modelos.Producto", "Producto")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("Producto_id")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleCompra_Producto_id");

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ADI.ADB.modelos.DetalleVenta", b =>
                {
                    b.HasOne("ADI.ADB.modelos.Producto", "Producto")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("Producto_id")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleVenta_Producto_id");

                    b.HasOne("ADI.ADB.modelos.venta", "Venta")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("Venta_id")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleVenta_Venta_id");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Empleado", b =>
                {
                    b.HasOne("ADI.ADB.modelos.Rol", "rol")
                        .WithMany("Empleados")
                        .HasForeignKey("rol_id")
                        .IsRequired()
                        .HasConstraintName("FK_Employee_Rol_Id");

                    b.Navigation("rol");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Producto", b =>
                {
                    b.HasOne("ADI.ADB.modelos.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("Categoria_id")
                        .IsRequired()
                        .HasConstraintName("FK_Categoria_id");

                    b.HasOne("ADI.ADB.modelos.Linea", "Linea")
                        .WithMany("Productos")
                        .HasForeignKey("Linea_id")
                        .IsRequired()
                        .HasConstraintName("FK_Linea_id");

                    b.Navigation("Categoria");

                    b.Navigation("Linea");
                });

            modelBuilder.Entity("ADI.ADB.modelos.venta", b =>
                {
                    b.HasOne("ADI.ADB.modelos.Cliente", "Cliente")
                        .WithMany("venta")
                        .HasForeignKey("Cliente_id")
                        .IsRequired()
                        .HasConstraintName("FK_Venta_Cliente_id");

                    b.HasOne("ADI.ADB.modelos.Empleado", "Empleado")
                        .WithMany("venta")
                        .HasForeignKey("Empleado_id")
                        .IsRequired()
                        .HasConstraintName("FK_Venta_Empleado_id");

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Cliente", b =>
                {
                    b.Navigation("venta");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Compra", b =>
                {
                    b.Navigation("DetalleCompras");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Empleado", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("venta");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Linea", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Producto", b =>
                {
                    b.Navigation("DetalleCompras");

                    b.Navigation("DetalleVenta");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Proveedor", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("ADI.ADB.modelos.Rol", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("ADI.ADB.modelos.venta", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
