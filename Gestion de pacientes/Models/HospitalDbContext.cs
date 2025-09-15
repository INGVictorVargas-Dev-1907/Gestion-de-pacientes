using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_pacientes.Models;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }


    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacientesId).HasName("PK__Paciente__8C9D0BF761D1ED61");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Paciente__531402F3077D50F0").IsUnique();

            entity.HasIndex(e => e.NumeroDocumento, "UQ__Paciente__A420258813F8E7F4").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero).HasMaxLength(200);
            entity.Property(e => e.NombreCompleto).HasMaxLength(150);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoDocumento).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
