using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.ICustomServices
{
    public interface ICustomServices<T> where T : Base
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Insert(T obj);
        void Update(T obj);
        bool Delete(int Id);
    }
}
