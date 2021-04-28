using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Context;
using WC.Model;
using WC.Repository.Contracts;

namespace WC.Repository.Implementations
{
    public class AliasRepository : IAliasRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public AliasRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Alias> GetAliases()
        {
            return context.Aliases.ToList();
        }

        public Alias GetAliasById(int id)
        {
            return context.Aliases.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateAlias(Alias alias)
        {
            alias.Active = true;
            alias.DateOfCreation = DateTimeOffset.Now;
            alias.LastUpdate = DateTimeOffset.Now;
            context.Aliases.Add(alias);
        }

        public void DeleteAlias(int aliasId)
        {
            Alias alias = context.Aliases.Find(aliasId);
            context.Aliases.Remove(alias);
        }

        public void UpdateAlias(Alias alias)
        {
            alias.LastUpdate = DateTimeOffset.Now;
            context.Entry(alias).State = EntityState.Modified;
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
