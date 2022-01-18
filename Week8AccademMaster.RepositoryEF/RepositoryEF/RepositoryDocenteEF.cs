using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryEF.RepositoryEF
{
    internal class RepositoryDocenteEF : IRepository<Docente>
    {
        public Docente Add(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public bool Delete(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public IList<Docente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.ToList();
            }
        }

        public Docente Update(Docente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
