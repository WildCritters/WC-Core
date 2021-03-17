using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using WC.Context;
using WC.Model;
using WC.Repository.Contracts;

namespace WC.Repository.Implementations
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;
        private IFunctionRepository functionRepository;

        public RoleRepository(WildCrittersDBContext context, IFunctionRepository functionRepository)
        {
            this.context = context;
            this.functionRepository = functionRepository;
        }

        public IEnumerable<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return context.Roles.AsNoTracking()
            .Include(x => x.RoleFunctions).ThenInclude(y => y.Function)
            .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<RoleFunction> GetRoleFunctions(int id)
        {
            return context.Roles.AsNoTracking()
            .Include(x => x.RoleFunctions)
            .FirstOrDefault(x => x.Id == id)
            .RoleFunctions;
        }

        public void CreateRole(Role role, int[] functionIds)
        {
            IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                role.Active = true;
                role.DateOfCreation = DateTimeOffset.Now;
                role.LastUpdate = DateTimeOffset.Now;
                context.Roles.Add(role);

                IEnumerable<Function> functions = functionRepository.GetFunctions();
                foreach(int functionId in functionIds)
                {
                    RoleFunction roleFunction = new()
                    {
                        Active = functions.Any(function => function.Id == functionId),
                        FunctionId = functionId,
                        DateOfCreation = DateTimeOffset.Now,
                        RoleId = role.Id
                    };
                    context.RoleFunctions.Add(roleFunction);
                }
                context.SaveChanges();
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void UpdateRole(Role role)
        {
            role.LastUpdate = DateTimeOffset.Now;
            context.Entry(role).State = EntityState.Modified;
        }

        public void UpdateRoleFunction(RoleFunction roleFunction)
        {
            roleFunction.LastUpdate = DateTimeOffset.Now;
            context.Entry(roleFunction).State = EntityState.Modified;
        }

        public void DeleteRoleFunction(RoleFunction roleFunction)
        {
            context.RoleFunctions.Remove(roleFunction);
        }

        public void DeleteRole(int roleId)
        {
            Role role = context.Roles.Find(roleId);
            context.Roles.Remove(role);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}