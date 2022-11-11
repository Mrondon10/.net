using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? ClientePrestatario { get; set; }

    public int? ClienteFiador { get; set; }

    public DateTime? FechaSolicitudPrestamo { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaTermino { get; set; }

    public double? MontoPrestamo { get; set; }

    public double? TasaInteres { get; set; }

    public int? TiempoAmortizacionMeses { get; set; }

    public bool? Aprovado { get; set; }

    public string Vigencia { get; set; } = null!;

    public int? IdGarantia { get; set; }

    public virtual Cliente? ClienteFiadorNavigation { get; set; }

    public virtual Cliente? ClientePrestatarioNavigation { get; set; }

    public virtual ICollection<CuotasPrestamo> CuotasPrestamos { get; } = new List<CuotasPrestamo>();

    public virtual Garantium? IdGarantiaNavigation { get; set; }
}
