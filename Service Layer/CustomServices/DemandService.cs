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
    public class DemandService : ICustomServices<Demand>
    {
        private readonly IRepository<Demand> _demand;
        public DemandService(IRepository<Demand> demand)
        {
            _demand = demand;
        }

        public bool Delete(int Id)
        {
            _demand.Delete(Id);
            _demand.SaveChange();
            return true;
        }

        public IEnumerable<Demand> GetAll()
        {
            return _demand.GetAll();
        }

        public Demand GetById(int Id)
        {
            return _demand.GetById(Id);
        }

        public void Insert(Demand obj)
        {
            _demand.Add(obj);
            _demand.SaveChange();
        }

        public void Update(Demand obj)
        {
            _demand.Update(obj);
            _demand.SaveChange();
        }
    }
}
