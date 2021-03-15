using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.API.Model.User
{
    public class GetUsersResponse
    {
        public IEnumerable<WC.DTO.User> Users { get; set; }
    }
}