using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<CuentaBancarium> CuentaBancaria { get; } = new List<CuentaBancarium>();

    public virtual ICollection<IntermediaClienteRol> IntermediaClienteRols { get; } = new List<IntermediaClienteRol>();

    public virtual ICollection<Inversione> Inversiones { get; } = new List<Inversione>();

    public virtual ICollection<Prestamo> PrestamoClienteFiadorNavigations { get; } = new List<Prestamo>();

    public virtual ICollection<Prestamo> PrestamoClientePrestatarioNavigations { get; } = new List<Prestamo>();
}
