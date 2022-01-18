using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryMock
{
    public class RepositoryCorsoMock : IRepositoryCorso
    {
        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso{CodiceCorso="C-01", Nome="Pre-Accademy",Descrizione="C# Corso base"},
        new Corso{CodiceCorso="C-02", Nome="Pre-Accademy",Descrizione="Sql Corso base"}
};
        public Corso Add(Corso item)
        {
            Corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            Corsi.Remove(item);
            return true;
        }

        public IList<Corso> GetAll()
        {
            return Corsi;
        }

        public Corso GetByCode(string codice)
        {
            return Corsi.FirstOrDefault(c=>c.CodiceCorso==codice);
        }

        public Corso Update(Corso item)
        {
            foreach (var c in Corsi)
            {
                if (c.CodiceCorso == item.CodiceCorso)
                {
                    c.Nome = item.Nome;
                    c.Descrizione = item.Descrizione;
                    return c;
                }
            }
            return null;
        }
    }
    }
    
