using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryMock
{
    public class RepositoryLezioneMock : IRepositoryLezione
    {
        public static List<Lezione> Lezioni = new List<Lezione>()
        {
            new Lezione{LezioneID=1, OrarioInizio=new DateTime(2022,01,01),Durata=45,Aula="marioRossi"},
            new Lezione{LezioneID=2, OrarioInizio=new DateTime(2022,01,15),Durata=50,Aula="mario"}
        };
        public Lezione Add(Lezione item)
        {
            if (Lezioni.Count == 0)
            {
                item.LezioneID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var s in Lezioni)
                {
                    if (s.LezioneID > maxId)
                    {
                        maxId = s.LezioneID;
                    }
                }
                item.LezioneID = maxId + 1;
            }
            Lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            Lezioni.Remove(item);
            return true;
        }

        public IList<Lezione> GetAll()
        {
            return Lezioni; ;
        }

        public Lezione GetById(int ID)
        {
            return Lezioni.FirstOrDefault(c => c.LezioneID == ID);
        }

        public Lezione Update(Lezione item)
        {
            foreach (var c in Lezioni)
            {
                if (c.LezioneID == item.LezioneID)
                {

                    c.Aula = item.Aula;

                    return c;
                }
            }
            return null;
        }
    }
    }

