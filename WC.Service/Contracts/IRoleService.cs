using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;
using WC.Repository.Implementations;
using WC.Service.Contracts;

namespace WC.Service.Contracts
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int roleId);
        void CreateRole(string name);
        void DeleteRole(int roleId);
        void UpdateRole(string name, int roleId);
        void AssignFunction(int roleId, List<int> functionsId);
    }
}