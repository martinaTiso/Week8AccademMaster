using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AccademMaster.Core.Entities
{
    public class Corso
    {

        public string CodiceCorso { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }


        public IList<Studente> Studenti { get; set;}=new List<Studente>();
        public IList<Lezione> Lezioni { get; set; }=new List<Lezione>();


        public override string ToString()
        {
            return $"{CodiceCorso}-{Nome}-{Descrizione}" ;
        }
    }
}
