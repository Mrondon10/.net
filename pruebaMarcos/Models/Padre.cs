using System;
using System.Collections.Generic;

namespace pruebaMarcos.Models;

public partial class Padre
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estatus { get; set; }

    public virtual ICollection<Hijo> Hijos { get; } = new List<Hijo>();
}
