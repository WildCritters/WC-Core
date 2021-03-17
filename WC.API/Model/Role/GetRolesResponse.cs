using System.Collections.Generic;
namespace WC.API.Model.Role
{
    public class GetRolesResponse
    {
        public IEnumerable<DTO.Role> Roles { get; set; }
    }
}
