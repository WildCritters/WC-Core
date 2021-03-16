using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public RoleRepository(WildCrittersDBContext context)
        {
            this.context = context;
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

        public void CreateRole(Role role)
        {
            role.Active = true;
            role.DateOfCreation = DateTimeOffset.Now;
            role.LastUpdate = DateTimeOffset.Now;
            context.Roles.Add(role);
        }

        public void UpdateRole(Role role)
        {
            role.LastUpdate = DateTimeOffset.Now;
            context.Entry(role).State = EntityState.Modified;
        }

        public void UpdateRoleFunction(RoleFunction roleFunction)
        {
            
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