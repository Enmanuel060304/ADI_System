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

    public virtual DbSet<ROLE> ROLEs { get; set; }

    public virtual DbSet<VENTum> VENTAs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CATEGORIum>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__CATEGORI__3214EC278800C849");

            entity.HasOne(d => d.ID_LINEANavigation).WithMany(p => p.CATEGORIa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATEGORIA__ID_LI__2A4B4B5E");
        });

        modelBuilder.Entity<CLIENTE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__CLIENTE__3214EC2773149E9F");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<COMPRA>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__COMPRA__3214EC27659C4F16");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_PROVEEDORNavigation).WithMany(p => p.COMPRAs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMPRA__ID_PROVE__403A8C7D");

            entity.HasOne(d => d.Id_EMPLEADONavigation).WithMany(p => p.COMPRAs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMPRA__Id_EMPLE__412EB0B6");
        });

        modelBuilder.Entity<DETALLE_COMPRA>(entity =>
        {
            entity.HasOne(d => d.ID_COMPRANavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_C__ID_CO__4316F928");

            entity.HasOne(d => d.ID_PRODUCTONavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_C__ID_PR__440B1D61");
        });

        modelBuilder.Entity<DETALLE_VENTum>(entity =>
        {
            entity.HasOne(d => d.ID_PRODUCTONavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_V__ID_PR__3D5E1FD2");

            entity.HasOne(d => d.ID_VENTANavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_V__ID_VE__3C69FB99");
        });

        modelBuilder.Entity<EMPLEADO>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__EMPLEADO__3214EC270035FE5A");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_ROLENavigation).WithMany(p => p.EMPLEADOs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEADO__ID_ROL__31EC6D26");
        });

        modelBuilder.Entity<LINEA>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__LINEA__3214EC276467D2D9");
        });

        modelBuilder.Entity<PRODUCTO>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__PRODUCTO__3214EC275CFF4721");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_CATEGORIANavigation).WithMany(p => p.PRODUCTOs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTO__ID_CAT__2D27B809");
        });

        modelBuilder.Entity<PROVEEDOR>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__PROVEEDO__3214EC27C1D7298C");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<ROLE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ROLE__3214EC2770120B4D");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<VENTum>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__VENTA__3214EC27BF92906C");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.ID_CLIENTENavigation).WithMany(p => p.VENTa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__ID_CLIENT__38996AB5");

            entity.HasOne(d => d.ID_EMPLEADONavigation).WithMany(p => p.VENTa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__ID_EMPLEA__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
