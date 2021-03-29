using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;
using WC.Repository.Implementations;
using WC.Service.Contracts;

namespace WC.Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _repository.GetRoles();
            return mapper.Map<IEnumerable<Model.Role>, IEnumerable<Role>>(roles);
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return mapper.Map<Model.Role, Role>(await _repository.GetRoleById(roleId));
        }

        public void CreateRole(string name, int[] functionsId)
        {
            Role role = new(){
                Name = name
            };
            _repository.CreateRole(mapper.Map<Role,Model.Role>(role), functionsId);
        }

        public void DeleteLogicRole(int roleId)
        {
            Role role = mapper.Map<Model.Role, Role>(_repository.GetRoleById(roleId).Result);
            role.Active = false;
            _repository.UpdateRole(mapper.Map<Role, Model.Role>(role));
        }

        public void DeleteRole(int roleId) 
        {
            IEnumerable<RoleFunction> roleFunctions =
            mapper.Map<IEnumerable<Model.RoleFunction>, IEnumerable<RoleFunction>>(_repository.GetRoleFunctions(roleId));

            foreach (RoleFunction function in roleFunctions)
            {
                _repository.DeleteRoleFunction(mapper.Map<RoleFunction, Model.RoleFunction>(function));
            }

            _repository.DeleteRole(roleId);
            _repository.Save();
        }

        public void UpdateRole(string name, int[] functionsId, int roleId)
        {
            Role role = mapper.Map<Model.Role, Role>(_repository.GetRoleById(roleId).Result);
            role.Name = name;
            _repository.UpdateRole(mapper.Map<Role, Model.Role>(role));
        }

        public void AssignFunction(int roleId, int[] functionsId)
        {
            IEnumerable<RoleFunction> roleFunctions = 
            mapper.Map<IEnumerable<Model.RoleFunction>, IEnumerable<RoleFunction>>(_repository.GetRoleFunctions(roleId));

            foreach (RoleFunction function in roleFunctions)
            {
                function.Active = functionsId.Any(x => x == function.FunctionId);
                _repository.UpdateRoleFunction(mapper.Map<RoleFunction, Model.RoleFunction>(function));
            }

            _repository.Save();
        }
    }
}