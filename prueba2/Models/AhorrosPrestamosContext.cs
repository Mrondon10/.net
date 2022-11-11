using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba2.Models;

public partial class AhorrosPrestamosContext : DbContext
{
    public AhorrosPrestamosContext()
    {
    }

    public AhorrosPrestamosContext(DbContextOptions<AhorrosPrestamosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CuentaBancarium> CuentaBancaria { get; set; }

    public virtual DbSet<CuotasPrestamo> CuotasPrestamos { get; set; }

    public virtual DbSet<Garantium> Garantia { get; set; }

    public virtual DbSet<IntermediaClienteRol> IntermediaClienteRols { get; set; }

    public virtual DbSet<Inversione> Inversiones { get; set; }

    public virtual DbSet<Mora> Moras { get; set; }

    public virtual DbSet<PagoInversion> PagoInversions { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<RolCliente> RolClientes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLlocaldb;Database=AhorrosPrestamos;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTES__677F38F56C082DAF");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<CuentaBancarium>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__CUENTA_B__C7E28685930AE605");

            entity.ToTable("CUENTA_BANCARIA");

            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.Banco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("banco");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NumeroCuenta).HasColumnName("numero_cuenta");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_cuenta");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CuentaBancaria)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__CUENTA_BA__id_cl__5812160E");
        });

        modelBuilder.Entity<CuotasPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdCuota).HasName("PK__CUOTAS_P__5EFF6F7E5FB46CD7");

            entity.ToTable("CUOTAS_PRESTAMO");

            entity.Property(e => e.IdCuota).HasColumnName("id_cuota");
            entity.Property(e => e.CuotaMensual).HasColumnName("Cuota_Mensual");
            entity.Property(e => e.DeudaCapital).HasColumnName("Deuda_Capital");
            entity.Property(e => e.DeudaInteres).HasColumnName("Deuda_Interes");
            entity.Property(e => e.FechaEfectivaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fecha_efectiva_pago");
            entity.Property(e => e.FechaPlanificadaPago)
                .HasColumnType("date")
                .HasColumnName("fecha_planificada_pago");
            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.InteresesMensual).HasColumnName("Intereses_Mensual");
            entity.Property(e => e.ModalidadPago)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modalidad_pago");
            entity.Property(e => e.MontoPagado).HasColumnName("Monto_Pagado");
            entity.Property(e => e.PagadoPrestamo).HasColumnName("Pagado_Prestamo");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.CuotasPrestamos)
                .HasForeignKey(d => d.IdPrestamo)
                .HasConstraintName("FK__CUOTAS_PR__id_pr__4AB81AF0");
        });

        modelBuilder.Entity<Garantium>(entity =>
        {
            entity.HasKey(e => e.IdGarantia).HasName("PK__GARANTIA__63A683D4CD18DE4B");

            entity.ToTable("GARANTIA");

            entity.Property(e => e.IdGarantia).HasColumnName("id_garantia");
            entity.Property(e => e.CodigoGarantia).HasColumnName("codigo_garantia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.TipoGarantia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_garantia");
            entity.Property(e => e.UbicacionGarantia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubicacion_garantia");
            entity.Property(e => e.ValorGarantia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_garantia");
        });

        modelBuilder.Entity<IntermediaClienteRol>(entity =>
        {
            entity.HasKey(e => e.IdIntermediaClienteRol).HasName("PK__INTERMED__1422FA5A40DE6F65");

            entity.ToTable("INTERMEDIA_CLIENTE_ROL");

            entity.Property(e => e.IdIntermediaClienteRol).HasColumnName("id_intermedia_cliente_rol");
            entity.Property(e => e.IdClienteIntermedia).HasColumnName("id_cliente_intermedia");
            entity.Property(e => e.IdRolClienteIntermedia).HasColumnName("id_rol_cliente_intermedia");

            entity.HasOne(d => d.IdClienteIntermediaNavigation).WithMany(p => p.IntermediaClienteRols)
                .HasForeignKey(d => d.IdClienteIntermedia)
                .HasConstraintName("FK__INTERMEDI__id_cl__3A81B327");

            entity.HasOne(d => d.IdRolClienteIntermediaNavigation).WithMany(p => p.IntermediaClienteRols)
                .HasForeignKey(d => d.IdRolClienteIntermedia)
                .HasConstraintName("FK__INTERMEDI__id_ro__3B75D760");
        });

        modelBuilder.Entity<Inversione>(entity =>
        {
            entity.HasKey(e => e.IdInversion).HasName("PK__INVERSIO__F5B400489AC0941B");

            entity.ToTable("INVERSIONES");

            entity.Property(e => e.IdInversion).HasColumnName("id_inversion");
            entity.Property(e => e.FechaRealizadaInversion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fecha_realizada_inversion");
            entity.Property(e => e.FechaTerminoInversion)
                .HasColumnType("date")
                .HasColumnName("fecha_termino_inversion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.MontoInversion).HasColumnName("monto_inversion");
            entity.Property(e => e.TasaInversionInteres).HasColumnName("tasa_inversion_interes");
            entity.Property(e => e.TiempoInversion).HasColumnName("Tiempo_Inversion");
            entity.Property(e => e.TipoInversion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_inversion");
            entity.Property(e => e.Vigente)
                .HasDefaultValueSql("((0))")
                .HasColumnName("vigente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Inversiones)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__INVERSION__id_cl__5070F446");
        });

        modelBuilder.Entity<Mora>(entity =>
        {
            entity.HasKey(e => e.IdMora).HasName("PK__MORAS__82C0334C9EA76660");

            entity.ToTable("MORAS");

            entity.Property(e => e.IdMora).HasColumnName("id_mora");
            entity.Property(e => e.DiasAtraso).HasColumnName("dias_atraso");
            entity.Property(e => e.IdCuotaPrestamo).HasColumnName("id_cuota_prestamo");
            entity.Property(e => e.InteresMoratorios)
                .HasComputedColumnSql("((([tasa_interes_anual_moratorio]*[monto_pago_vencido])/(360))*[dias_atraso])", false)
                .HasColumnName("interesMoratorios");
            entity.Property(e => e.MontoPagoVencido).HasColumnName("monto_pago_vencido");
            entity.Property(e => e.TasaInteresAnualMoratorio).HasColumnName("tasa_interes_anual_moratorio");

            entity.HasOne(d => d.IdCuotaPrestamoNavigation).WithMany(p => p.Moras)
                .HasForeignKey(d => d.IdCuotaPrestamo)
                .HasConstraintName("FK__MORAS__id_cuota___5DCAEF64");
        });

        modelBuilder.Entity<PagoInversion>(entity =>
        {
            entity.HasKey(e => e.IdCuotaInversion).HasName("PK__PAGO_INV__F5E4D6CFA0100381");

            entity.ToTable("PAGO_INVERSION");

            entity.Property(e => e.IdCuotaInversion).HasColumnName("id_cuota_inversion");
            entity.Property(e => e.ComprobantePago).HasColumnName("comprobante_pago");
            entity.Property(e => e.FechaEfectivaPago)
                .HasColumnType("date")
                .HasColumnName("fecha_efectiva_pago");
            entity.Property(e => e.FechaPlanificadaPago)
                .HasColumnType("date")
                .HasColumnName("fecha_planificada_pago");
            entity.Property(e => e.IdInversion).HasColumnName("id_inversion");
            entity.Property(e => e.ModalidadPago)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modalidad_pago");
            entity.Property(e => e.MontoPagado).HasColumnName("Monto_Pagado");

            entity.HasOne(d => d.IdInversionNavigation).WithMany(p => p.PagoInversions)
                .HasForeignKey(d => d.IdInversion)
                .HasConstraintName("FK__PAGO_INVE__id_in__5441852A");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__PRESTAMO__5E87BE27EFAD2DC6");

            entity.ToTable("PRESTAMOS");

            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.Aprovado)
                .HasDefaultValueSql("((0))")
                .HasColumnName("aprovado");
            entity.Property(e => e.ClienteFiador).HasColumnName("cliente_fiador");
            entity.Property(e => e.ClientePrestatario).HasColumnName("cliente_prestatario");
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("date")
                .HasColumnName("fecha_aprobacion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaSolicitudPrestamo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fecha_solicitud_prestamo");
            entity.Property(e => e.FechaTermino)
                .HasColumnType("date")
                .HasColumnName("fecha_termino");
            entity.Property(e => e.IdGarantia).HasColumnName("id_garantia");
            entity.Property(e => e.MontoPrestamo).HasColumnName("monto_prestamo");
            entity.Property(e => e.TasaInteres).HasColumnName("tasa_interes");
            entity.Property(e => e.TiempoAmortizacionMeses).HasColumnName("Tiempo_Amortizacion_Meses");
            entity.Property(e => e.Vigencia)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ClienteFiadorNavigation).WithMany(p => p.PrestamoClienteFiadorNavigations)
                .HasForeignKey(d => d.ClienteFiador)
                .HasConstraintName("FK__PRESTAMOS__clien__4222D4EF");

            entity.HasOne(d => d.ClientePrestatarioNavigation).WithMany(p => p.PrestamoClientePrestatarioNavigations)
                .HasForeignKey(d => d.ClientePrestatario)
                .HasConstraintName("FK__PRESTAMOS__clien__412EB0B6");

            entity.HasOne(d => d.IdGarantiaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdGarantia)
                .HasConstraintName("FK__PRESTAMOS__id_ga__45F365D3");
        });

        modelBuilder.Entity<RolCliente>(entity =>
        {
            entity.HasKey(e => e.IdRolCliente).HasName("PK__ROL_CLIE__1B73D5D394CABE55");

            entity.ToTable("ROL_CLIENTES");

            entity.Property(e => e.IdRolCliente).HasColumnName("id_rol_cliente");
            entity.Property(e => e.TipoRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__4E3E04ADAF7ABA72");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido_usuario");
            entity.Property(e => e.CedulaUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cedula_usuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.PuestoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("puesto_usuario");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
