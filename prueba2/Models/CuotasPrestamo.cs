using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class CuotasPrestamo
{
    public int IdCuota { get; set; }

    public int? Cuotas { get; set; }

    public DateTime? FechaPlanificadaPago { get; set; }

    public double? CuotaMensual { get; set; }

    public double? MontoPagado { get; set; }

    public double? InteresesMensual { get; set; }

    public double? PagadoPrestamo { get; set; }

    public double? DeudaCapital { get; set; }

    public double? DeudaInteres { get; set; }

    public DateTime? FechaEfectivaPago { get; set; }

    public double? Abono { get; set; }

    public string ModalidadPago { get; set; } = null!;

    public int? IdPrestamo { get; set; }

    public virtual Prestamo? IdPrestamoNavigation { get; set; }

    public virtual ICollection<Mora> Moras { get; } = new List<Mora>();
}
