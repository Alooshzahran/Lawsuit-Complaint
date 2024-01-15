using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Repository_layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_layer.Repository
{
    public class Repository<T> : IRepository<T> where T : Base
    { 
        private readonly MyDbContext _db;
        private readonly DbSet<T> Entity;
        public Repository(MyDbContext db)
        {
            _db = db;
            Entity = _db.Set<T>();
        }
        public T Add(T obj)
        {
             Entity.Add(obj);
              return obj;
        }

        public bool Delete(int Id)
        {
            Entity.Remove(GetById(Id));
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return Entity.AsEnumerable();
        }

        public T GetById(int id)
        {
            return Entity.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public T Update(T obj)
        {
           Entity.Update(obj);
            return obj;
        }
    }
}
