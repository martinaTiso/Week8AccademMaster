using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;

namespace Week8AccademMaster.Core.InterfaceRepository
{
    public interface IRepositoryStudente : IRepository<Studente>
    {

        public Studente GetById(int ID);
        public List<Studente> GetByCorsoCodice(string CorsoCodice)
        {
            return GetAll().Where(s=>s.CorsoCodice == CorsoCodice).ToList();
        }
    }
}
