using System.Collections.Generic;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int id);
        IEnumerable<RoleFunction> GetRoleFunctions(int id);
        void CreateRole(Role role, int[] functionIds);
        void UpdateRole(Role role);
        void UpdateRoleFunction(RoleFunction roleFunction);
        void DeleteRole(int roleId);
        void Save();
    }
}