using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryEF.RepositoryEF
{
    internal class RepositoryStudentiEF : IRepository<Studente>
    {
        public Studente Add(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public bool Delete(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public IList<Studente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.ToList();
            }
        }

        public Studente Update(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
