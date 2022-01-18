using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AccademMaster.Core.Entities
{
    public class Docente:Persona
    {
        public string Telefono { get; set; }

        public IList<Lezione> Lezione { get; set; }= new List<Lezione>();


        public override string ToString()
        {
            return base.ToString() + $" telefono {Telefono}";
        }
    }
}
