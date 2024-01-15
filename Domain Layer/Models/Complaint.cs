using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Complaint :Base
    {
        public int UserId { get; set; }
        public bool State { get; set; }

        public virtual User? User { get; set; }
        public List<Demand> Demands { get; set; }
    }
}
