using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class User : Base
    {
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? Email { get; set; }
    }
}
