using System;
using System.Collections.Generic;

namespace ensueno.DataBase;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreCompleto { get; set; }

    public byte[] Imagen { get; set; }

    public int? IdCargo { get; set; }

    public string NumCedula { get; set; }

    public int? IdSucursal { get; set; }

    public bool? Activo { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; }

    public virtual Sucursale IdSucursalNavigation { get; set; }
}
