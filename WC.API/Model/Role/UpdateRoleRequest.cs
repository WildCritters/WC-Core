using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.API.Model.Role
{
    public class UpdateRoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] FunctionsId { get; set; }
    }
}
