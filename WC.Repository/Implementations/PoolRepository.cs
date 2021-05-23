using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public class PoolRepository
    {
        private readonly WildCrittersDBContext context;

        public PoolRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pool> GetPools()
        {
            return context.Pools.ToList();
        }

        public Pool GetPoolById(int id)
        {
            return context.Pools.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreatePool(Pool pool)
        {
            pool.Active = true;
            pool.DateOfCreation = DateTimeOffset.Now;
            pool.LastUpdate = DateTimeOffset.Now;
            context.Pools.Add(pool);
        }

        public void DeletePool(int poolId)
        {
            Pool pool = context.Pools.Find(poolId);
            context.Pools.Remove(pool);
        }

        public void UpdatePool(Pool pool)
        {
            pool.LastUpdate = DateTimeOffset.Now;
            context.Entry(pool).State = EntityState.Modified;
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
