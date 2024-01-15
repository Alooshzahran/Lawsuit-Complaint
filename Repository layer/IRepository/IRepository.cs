using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_layer.IRepository
{
    public interface IRepository<T> where T : Base
    {
        IEnumerable<T> GetAll();
        T GetById(int id); 
        T Add(T obj);
        T Update(T obj);
        bool Delete(int Id);
        void SaveChange();
    }
}
