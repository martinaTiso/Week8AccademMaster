using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryMock
{
    public class RepositoryStudenteMock : IRepositoryStudente
    {
        public static List<Studente> Studenti = new List<Studente>()
        {
            new Studente{ID=1, Nome="Mario",Cognome="Rossi",DataNascita= new DateTime(1991,05,02),Email="marioRossi@gmail.com",TitoloStudio="laurea triennale"},
            new Studente{ID=2, Nome="Martina",Cognome="tiso",DataNascita=new DateTime(2010,05,02),Email="martinatiso@gmail.com",TitoloStudio="laurea triennale"}
        };

        public Studente Add(Studente item)
        {
            if (Studenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var s in Studenti)
                {
                    if (s.ID > maxId)
                    {
                        maxId = s.ID;
                    }
                }
                item.ID = maxId + 1;
            }
            Studenti.Add(item);
            return item;
        
    }

        public bool Delete(Studente item)
        {
            Studenti.Remove(item);
            return true;
        }

        public IList<Studente> GetAll()
        {
            return Studenti;
        }

        public Studente GetById(int ID)
        {
            return Studenti.FirstOrDefault(c => c.ID == ID);
        }

        public Studente Update(Studente item)
        {
            foreach (var c in Studenti)
            {
                if (c.ID == item.ID)
                {
                    
                    c.Email = item.Email;
                    
                    return c;
                }
            }
            return null;
        }
    }
}
