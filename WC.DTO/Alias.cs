using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Alias : EntityModel
    {
        public string Name { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public virtual User User { get; set; }
    }
}
