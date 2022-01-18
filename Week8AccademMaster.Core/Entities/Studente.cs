using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AccademMaster.Core.Entities
{
    public class Studente : Persona
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }


        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }


        public override string ToString()
        {
            return base.ToString()+ $"nato il {DataNascita.ToShortDateString()}-Titolo Studio: {TitoloStudio}";
        }
    }
}
