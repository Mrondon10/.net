using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class IntermediaClienteRol
{
    public int IdIntermediaClienteRol { get; set; }

    public int? IdClienteIntermedia { get; set; }

    public int? IdRolClienteIntermedia { get; set; }

    public virtual Cliente? IdClienteIntermediaNavigation { get; set; }

    public virtual RolCliente? IdRolClienteIntermediaNavigation { get; set; }
}
