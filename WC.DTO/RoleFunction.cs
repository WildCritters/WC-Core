using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class RoleFunction : EntityModel
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int FunctionId { get; set; }
        public Function Function { get; set; }
    }
}
