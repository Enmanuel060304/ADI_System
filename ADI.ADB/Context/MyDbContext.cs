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

    public virtual DbSet<CATEGORIum> CATEGORIAs { get; set; }

    public virtual DbSet<CLIENTE> CLIENTEs { get; set; }

    public virtual DbSet<COMPRA> COMPRAs { get; set; }

    public virtual DbSet<DETALLE_COMPRA> DETALLE_COMPRAs { get; set; }

    public virtual DbSet<DETALLE_VENTum> DETALLE_VENTAs { get; set; }

    public virtual DbSet<EMPLEADO> EMPLEADOs { get; set; }

    public virtual DbSet<LINEA> LINEAs { get; set; }

    public virtual DbSet<PRODUCTO> PRODUCTOs { get; set; }

    public virtual DbSet<PROVEEDOR> PROVEEDORs { get; set; }

    public virtual DbSet<ROLE> ROLES{ get; set; }

    public virtual DbSet<VENTum> VENTAs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ADI_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CATEGORIum>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__CATEGORI__3214EC271ECA4575");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_LINEANavigation).WithMany(p => p.CATEGORIa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATEGORIA__ID_LI__31EC6D26");
        });

        modelBuilder.Entity<CLIENTE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__CLIENTE__3214EC27D7D5F17E");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<COMPRA>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__COMPRA__3214EC27FEE2A5FB");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_PROVEEDORNavigation).WithMany(p => p.COMPRAs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMPRA__ID_PROVE__3A81B327");

            entity.HasOne(d => d.Id_EMPLEADONavigation).WithMany(p => p.COMPRAs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMPRA__Id_EMPLE__3B75D760");
        });

        modelBuilder.Entity<DETALLE_COMPRA>(entity =>
        {
            entity.HasOne(d => d.ID_COMPRANavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_C__ID_CO__3D5E1FD2");

            entity.HasOne(d => d.ID_PRODUCTONavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_C__ID_PR__3E52440B");
        });

        modelBuilder.Entity<DETALLE_VENTum>(entity =>
        {
            entity.HasOne(d => d.ID_PRODUCTONavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_V__ID_PR__37A5467C");

            entity.HasOne(d => d.ID_VENTANavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_V__ID_VE__36B12243");
        });

        modelBuilder.Entity<EMPLEADO>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__EMPLEADO__3214EC276CC2D433");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_ROLENavigation).WithMany(p => p.EMPLEADOs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEADO__ID_ROL__25869641");
        });

        modelBuilder.Entity<LINEA>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__LINEA__3214EC272446ED71");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<PRODUCTO>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__PRODUCTO__3214EC2796943525");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_CATEGORIANavigation).WithMany(p => p.PRODUCTOs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTO__ID_CAT__34C8D9D1");
        });

        modelBuilder.Entity<PROVEEDOR>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__PROVEEDO__3214EC27B89A6A89");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<ROLE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ROLE__3214EC278FC728EB");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<VENTum>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__VENTA__3214EC274AE9EC84");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_CLIENTENavigation).WithMany(p => p.VENTa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__ID_CLIENT__2C3393D0");

            entity.HasOne(d => d.ID_EMPLEADONavigation).WithMany(p => p.VENTa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__ID_EMPLEA__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
