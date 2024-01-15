using Domain_Layer.Models;
using Repository_layer.IRepository;
using Service_Layer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.CustomServices
{
    public class UserService : ICustomServices<User>
    {
        private readonly IRepository<User> _user;
        public UserService(IRepository<User> user)
        {
            _user = user;
        }
        public bool Delete(int Id)
        {
            _user.Delete(Id);
            _user.SaveChange();
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _user.GetAll();
        }

        public User GetById(int Id)
        {
            return _user.GetById(Id);
        }

        public void Insert(User obj)
        {
            _user.Add(obj);
            _user.SaveChange();
        }

        public void Update(User obj)
        {
            _user.Update(obj);
            _user.SaveChange();
        }
    }
}
