using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AccademMaster.Core.Entities
{
    public class Lezione 
    {
        public int LezioneID { get; set; }
        public DateTime OrarioInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }


        
        public int DocenteID { get; set; }
        public Docente Docente { get; set; }

        //Fk verso corso

        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return  $"Lezione{LezioneID}-Data{OrarioInizio} - Aula{Aula} - Durata in gg : {Durata}";
        }

    }
}
