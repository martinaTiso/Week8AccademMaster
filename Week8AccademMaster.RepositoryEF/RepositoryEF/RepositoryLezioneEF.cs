using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryEF.RepositoryEF
{
    public class RepositoryLezioneEF : IRepository<Lezione>
    {
        public Lezione Add(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public bool Delete(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public IList<Lezione> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.ToList();
            }
        }

        public Lezione Update(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
