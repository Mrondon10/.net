using System;
using System.Collections.Generic;

namespace pruebaMarcos.Models;

public partial class Hijo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estatus { get; set; }

    public int? IdPadre { get; set; }

    public virtual Padre? IdPadreNavigation { get; set; }
}
