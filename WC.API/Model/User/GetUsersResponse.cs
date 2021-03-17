using System.Collections.Generic;

namespace WC.API.Model.User
{
    public class GetUsersResponse
    {
        public IEnumerable<WC.DTO.User> Users { get; set; }
    }
}