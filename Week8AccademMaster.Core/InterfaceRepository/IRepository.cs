using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AccademMaster.Core.InterfaceRepository
{
    public interface IRepository<T>
    {
        // Operazione in comune con tutte le entità ovvero le CRUD

        public IList<T> GetAll();

        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
        
        /*public T GetById(int id);*/ // non lo posso usare perche non tutti hanno un int
    }
}
