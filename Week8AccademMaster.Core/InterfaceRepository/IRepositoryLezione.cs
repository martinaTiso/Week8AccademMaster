using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;

namespace Week8AccademMaster.Core.InterfaceRepository
{
    internal interface IRepositoryLezione : IRepository<Lezione>
    {

        public Lezione GetById(int ID);
    
    }
}
