using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class RolCliente
{
    public int IdRolCliente { get; set; }

    public string? TipoRol { get; set; }

    public virtual ICollection<IntermediaClienteRol> IntermediaClienteRols { get; } = new List<IntermediaClienteRol>();
}
