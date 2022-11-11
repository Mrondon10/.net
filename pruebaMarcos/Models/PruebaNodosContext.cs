using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pruebaMarcos.Models;

public partial class PruebaNodosContext : DbContext
{
    public PruebaNodosContext()
    {
    }

    public PruebaNodosContext(DbContextOptions<PruebaNodosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hijo> Hijos { get; set; }

    public virtual DbSet<Padre> Padres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=pruebaNodos;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hijo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hijos__3213E83F64642DB3");

            entity.ToTable("hijos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estatus).HasColumnName("estatus");

            entity.HasOne(d => d.IdPadreNavigation).WithMany(p => p.Hijos)
                .HasForeignKey(d => d.IdPadre)
                .HasConstraintName("FK__hijos__IdPadre__267ABA7A");
        });

        modelBuilder.Entity<Padre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__padres__3213E83FB0F880FA");

            entity.ToTable("padres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estatus).HasColumnName("estatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
