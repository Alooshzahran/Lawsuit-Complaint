using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Demand : Base
    {
        public string? ComplaintText { get; set; }
        public int ComplaintId { get; set; }
        public string? PersonalId { get; set; }
        public virtual Complaint? Complaint { get; set; }
    }
}
