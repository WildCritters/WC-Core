using System.Collections.Generic;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int id);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int roleId);
        IEnumerable<RoleFunction> GetRoleFunctions(int id);
        void Save();
    }
}