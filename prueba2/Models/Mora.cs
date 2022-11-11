using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Mora
{
    public int IdMora { get; set; }

    public double? TasaInteresAnualMoratorio { get; set; }

    public double? MontoPagoVencido { get; set; }

    public int? DiasAtraso { get; set; }

    public double? InteresMoratorios { get; set; }

    public int? IdCuotaPrestamo { get; set; }

    public virtual CuotasPrestamo? IdCuotaPrestamoNavigation { get; set; }
}
