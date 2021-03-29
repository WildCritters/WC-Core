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
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleById(int roleId);
        void CreateRole(string name, int[] functionsId);
        void DeleteRole(int roleId);
        void DeleteLogicRole(int roleId);
        void UpdateRole(string name, int[] functionsId, int roleId);
        void AssignFunction(int roleId, int[] functionsId);
    }
}