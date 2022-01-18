using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;

namespace Week8AccademMaster.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        public List<Corso> GetAllCorsi();
        public Esito AddNuovoCorso(Corso nuovocorso);
        public Esito ModicaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione);
        public Esito RimuoviCorso(string? codice);
        public List<Studente> GetAllStudenti();
        public Esito AddNuovoStudente(Studente nuovoStudente);
        public Esito ModificaStudente(int id,  string? email);
        public Esito RimuoviStudente(int id);
        public List<Studente> GetStudentiByCorso(string? codice);
        public List<Docente> GetAllDocenti();
        public Esito AddNuovoDocente(Docente nuovoDocente);
        public Esito ModificaDocente(int id, string? email, string? numeroTelefono);
        public Esito RimuoviDocente(int id);
        public List<Lezione> GetAllLezione();
        public Esito AddNuovoLezione(Lezione nuovalezione);
       public  Esito ModificaLezione(int lezioneId, string? aula);
        public Esito RimuoviLezione(int lezioneid);
    }
}
