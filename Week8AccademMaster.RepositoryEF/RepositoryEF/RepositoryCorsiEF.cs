using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryEF.RepositoryEF
{
    public class RepositoryCorsiEF : IRepository<Corso>
    {
        public Corso Add(Corso item)
        {
            using(var ctx=new MasterContext())
            {
                ctx.Corsi.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public bool Delete(Corso item)
        {
            using (var ctx=new MasterContext())
            {
                ctx.Corsi.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public IList<Corso> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Corsi.ToList();
            }
        }

        public Corso Update(Corso item)
        {
           using(var ctx=new MasterContext())
            {
                ctx.Corsi.Update(item);
                ctx.SaveChanges();
            }
           return item;
        }
    }
}
