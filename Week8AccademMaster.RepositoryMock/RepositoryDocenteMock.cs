using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryMock
{
    public class RepositoryDocenteMock : IRepositoryDocente
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{ID=1, Nome="Marco",Cognome="Rosso",Email="marioRossi@gmail.com",Telefono="3475263737"},
            new Docente{ID=2, Nome="Marta",Cognome="tisu",Email="martinatiso@gmail.com",Telefono="34609088"}
        };
        public Docente Add(Docente item)
        {
            if (Docenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var s in Docenti)
                {
                    if (s.ID > maxId)
                    {
                        maxId = s.ID;
                    }
                }
                item.ID = maxId + 1;
            }
            Docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public IList<Docente> GetAll()
        {
            return Docenti;
        }

        public Docente GetByCode(int ID)
        {
            return Docenti.FirstOrDefault(c => c.ID ==ID);
        }

        public Docente Update(Docente item)
        {
            foreach (var c in Docenti)
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

