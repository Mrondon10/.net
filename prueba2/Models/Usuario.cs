using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public string? CedulaUsuario { get; set; }

    public string PuestoUsuario { get; set; } = null!;

    public string? Usuario1 { get; set; }

    public string? Clave { get; set; }
}
