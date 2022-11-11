using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class PagoInversion
{
    public int IdCuotaInversion { get; set; }

    public DateTime? FechaPlanificadaPago { get; set; }

    public DateTime? FechaEfectivaPago { get; set; }

    public double? MontoPagado { get; set; }

    public string ModalidadPago { get; set; } = null!;

    public int? ComprobantePago { get; set; }

    public int? IdInversion { get; set; }

    public virtual Inversione? IdInversionNavigation { get; set; }
}
