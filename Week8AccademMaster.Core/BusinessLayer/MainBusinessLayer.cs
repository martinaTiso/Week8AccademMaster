using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorso corsiRepo;
        private readonly IRepositoryStudente StudentiRepo;
        private readonly IRepositoryDocente DocentiRepo;
        private readonly IRepositoryLezione LezioniRepo;
        public MainBusinessLayer(IRepositoryCorso corsi, IRepositoryStudente studenti,IRepositoryDocente docenti,IRepositoryLezione lezioni)// gli passo qlksa che assegno poi a corsi repo
        {
            corsiRepo = corsi;
            StudentiRepo = studenti;
            DocentiRepo = docenti;
            LezioniRepo = lezioni;
        }

        public Esito AddNuovoCorso(Corso nuovocorso)
        {
            // controlllo se il codice inserito dall'utente esiste 
            //corsiRepo.GetAll().FirstOrDefault(c=>c.CodiceCorso == nuovocorso.CodiceCorso);
             Corso corsoEsistente=corsiRepo.GetByCode(nuovocorso.CodiceCorso);
            if (corsoEsistente == null)
            {
                corsiRepo.Add(nuovocorso);
                return new Esito { Messaggio = "Corso aggiunto correttamente" };
            }
            else
            {
                return new Esito { Messaggio = "Impossibile aggiungere il corso ,codice già esistente",IsOk=false };
            }
            
        }

        public Esito AddNuovoDocente(Docente nuovoDocente)
        {
            Docente docenteEsistente = DocentiRepo.GetByCode(nuovoDocente.ID);
            if (docenteEsistente == null)
            {
               DocentiRepo.Add(nuovoDocente);
                return new Esito { Messaggio = "Docente aggiunto correttamente" };
            }
            else
            {
                return new Esito { Messaggio = "Impossibile aggiungere il docente ,codice già esistente", IsOk = false };
            }
        }

        public Esito AddNuovoLezione(Lezione nuovalezione)
        {
            Lezione lezioneEsistente = LezioniRepo.GetById(nuovalezione.LezioneID);
            if (lezioneEsistente == null)
            {
               LezioniRepo.Add(lezioneEsistente);
                return new Esito { Messaggio = "lezione aggiunto correttamente" };
            }
            else
            {
                return new Esito { Messaggio = "Impossibile aggiungere la lezione ,codice già esistente", IsOk = false };
            }
        }

        public Esito AddNuovoStudente(Studente nuovoStudente)
        {
            Studente studenteEsistente = StudentiRepo.GetById(nuovoStudente.ID);
            if (studenteEsistente == null)
            {
                StudentiRepo.Add(nuovoStudente);
                return new Esito { Messaggio = "Studente aggiunto correttamente" };
            }
            else
            {
                return new Esito { Messaggio = "Impossibile aggiungere lo studente ,codice già esistente", IsOk = false };
            }
        }

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll().ToList();
        }

        public List<Docente> GetAllDocenti()
        {
           return DocentiRepo.GetAll().ToList();
        }

        public List<Lezione> GetAllLezione()
        {
            return LezioniRepo.GetAll().ToList();
        }

        public List<Studente> GetAllStudenti()
        {
            return StudentiRepo.GetAll().ToList();
        }

        public List<Studente> GetStudentiByCorso(string? codice)
        {
            throw new NotImplementedException();
        }

        //public List<Studente> GetStudentiByCorso(string? codice)
        //{
        //    var studenti= StudentiRepo.
        //}

        public Esito ModicaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione)
        {
            var corsoEsistente=corsiRepo.GetByCode(codice);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun corso con il codice che hai inserito",IsOk=false };
            }
            else
            {
                corsoEsistente.Nome=nuovoNome;
                corsoEsistente.Descrizione=nuovaDescrizione;

                //devo aggiornare la repo
                corsiRepo.Update(corsoEsistente);
                return new Esito { Messaggio ="Corso modidicato correttamente!!",IsOk=true };
            }
        }

        public Esito ModificaDocente(int id, string? email, string? numeroTelefono)
        {
            var docenteEsistente = DocentiRepo.GetByCode(id);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (docenteEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun docente con il codice che hai inserito", IsOk = false };
            }
            else
            {

                docenteEsistente.Email = email;

                //devo aggiornare la repo
               DocentiRepo.Update(docenteEsistente);
                return new Esito { Messaggio = "docente modidicato correttamente!!", IsOk = true };
            }

        }

        public Esito ModificaLezione(int lezioneId, string? aula)
        {
            var lezioneEsistente = LezioniRepo.GetById(lezioneId);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (lezioneEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessuna lezione con il codice che hai inserito", IsOk = false };
            }
            else
            {

                lezioneEsistente.Aula = aula;

                //devo aggiornare la repo
                LezioniRepo.Update(lezioneEsistente);
                return new Esito { Messaggio = "Lezione modidicata correttamente!!", IsOk = true };
            }

        }

        public Esito ModificaStudente(int id,  string? email)
        {
            var studenteEsistente = StudentiRepo.GetById(id);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (studenteEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun studente con il codice che hai inserito", IsOk = false };
            }
            else
            {
                
                studenteEsistente.Email=email;
               
                //devo aggiornare la repo
                StudentiRepo.Update(studenteEsistente);
                return new Esito { Messaggio = "Studente modidicato correttamente!!", IsOk = true };
            }
        }

        public Esito RimuoviCorso(string? codice)
        {
            var corsoEsistente = corsiRepo.GetByCode(codice);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun corso con il codice che hai inserito", IsOk = false };
            }
            else 
            {
                

                //devo cancellare nella repo il corso
                corsiRepo.Delete(corsoEsistente);
                return new Esito { Messaggio = "Corso rimosso correttamente!!", IsOk = true };
            }
        }

        public Esito RimuoviDocente(int id)
        {
            var docenteEsistente = DocentiRepo.GetByCode(id);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (docenteEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun docente con il codice che hai inserito", IsOk = false };
            }
            else
            {


                //devo cancellare nella repo il corso
                DocentiRepo.Delete(docenteEsistente);
                return new Esito { Messaggio = "docente rimosso correttamente!!", IsOk = true };
            }
        }

        public Esito RimuoviLezione(int lezioneid)
        {
            var lezioneEsistente = LezioniRepo.GetById(lezioneid);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (lezioneEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessuna lezione con il codice che hai inserito", IsOk = false };
            }
            else
            {


                //devo cancellare nella repo il corso
               LezioniRepo.Delete(lezioneEsistente);
                return new Esito { Messaggio = "lezione rimosso correttamente!!", IsOk = true };
            }
        }

        public Esito RimuoviStudente(int id)
        {
            var studenteEsistente = StudentiRepo.GetById(id);// controllo se esiste nel repository e lo memorizzo nella variabile
            if (studenteEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun studente con il codice che hai inserito", IsOk = false };
            }
            else
            {


                //devo cancellare nella repo il corso
                StudentiRepo.Delete(studenteEsistente);
                return new Esito { Messaggio = "Studente rimosso correttamente!!", IsOk = true };
            }
        }
    }
}
