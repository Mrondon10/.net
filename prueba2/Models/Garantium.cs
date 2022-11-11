using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Garantium
{
    public int IdGarantia { get; set; }

    public int? CodigoGarantia { get; set; }

    public string TipoGarantia { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? ValorGarantia { get; set; }

    public string? UbicacionGarantia { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
