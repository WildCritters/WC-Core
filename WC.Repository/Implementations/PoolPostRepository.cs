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
    public class PoolPostRepository : IPoolPostRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public PoolPostRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<PoolPost> GetPoolPosts()
        {
            return context.PoolPosts.ToList();
        }

        public PoolPost GetPoolPostById(int id)
        {
            return context.PoolPosts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreatePoolPost(PoolPost poolPost)
        {
            poolPost.Active = true;
            poolPost.DateOfCreation = DateTimeOffset.Now;
            poolPost.LastUpdate = DateTimeOffset.Now;
            context.PoolPosts.Add(poolPost);
        }

        public void DeletePoolPost(int poolPostId)
        {
            PoolPost poolPost = context.PoolPosts.Find(poolPostId);
            context.PoolPosts.Remove(poolPost);
        }

        public void UpdatePoolPost(PoolPost poolPost)
        {
            poolPost.LastUpdate = DateTimeOffset.Now;
            context.Entry(poolPost).State = EntityState.Modified;
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
