using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class RoleFunction : EntityModel
    {
        public Role Role { get; set; }
        public Function Function { get; set; }
    }
}
