using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class CuentaBancarium
{
    public int IdCuenta { get; set; }

    public long? NumeroCuenta { get; set; }

    public string? Banco { get; set; }

    public string TipoCuenta { get; set; } = null!;

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
