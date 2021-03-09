using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Role : EntityModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<Function> Functions { get; set; }
    }
}
