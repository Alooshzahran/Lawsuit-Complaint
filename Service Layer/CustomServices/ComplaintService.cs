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
    public class ComplaintService : ICustomServices<Complaint>
    {
        private readonly IRepository<Complaint> _complaint;
        public ComplaintService(IRepository<Complaint> complaint)
        {
            _complaint = complaint;
        }
        public bool Delete(int Id)
        {
            _complaint.Delete(Id);
            _complaint.SaveChange();
            return true;
        }

        public IEnumerable<Complaint> GetAll()
        {
           return _complaint.GetAll();
        }

        public Complaint GetById(int Id)
        {
           return _complaint.GetById(Id);
        }

        public void Insert(Complaint obj)
        {
             _complaint.Add(obj);
            _complaint.SaveChange();

        }

        public void Update(Complaint obj)
        {
            _complaint.Update(obj);
            _complaint.SaveChange();
        }
    }
}
