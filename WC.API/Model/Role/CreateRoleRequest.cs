using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.API.Model.Role
{
    public class CreateRoleRequest
    {
        public string Name { get; set; }
        public int[] FunctionsId { get; set; }
    }
}
