using System;
using System.Collections.Generic;

namespace ensueno.DataBase;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string NomCargo { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
