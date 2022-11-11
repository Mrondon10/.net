using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Inversione
{
    public int IdInversion { get; set; }

    public double? MontoInversion { get; set; }

    public int? TiempoInversion { get; set; }

    public string TipoInversion { get; set; } = null!;

    public double? TasaInversionInteres { get; set; }

    public DateTime? FechaRealizadaInversion { get; set; }

    public DateTime? FechaTerminoInversion { get; set; }

    public bool? Vigente { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<PagoInversion> PagoInversions { get; } = new List<PagoInversion>();
}
