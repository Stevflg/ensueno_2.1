using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Database
{
    public class Procedures
    {
        public int ProcedureId { get; set; }
        public string? ProcedureName { get; set; }
        public ICollection<ProcedureRols> ProceduresRolsCollections { get; set; } = new List<ProcedureRols>();
    }
}