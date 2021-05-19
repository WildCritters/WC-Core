using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public class FlaggedPostRepository
    {
        private readonly WildCrittersDBContext context;

        public FlaggedPostRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<FlaggedPost> GetFlaggedPosts()
        {
            return context.FlaggedPosts.ToList();
        }

        public FlaggedPost GetFlaggedPostById(int id)
        {
            return context.FlaggedPosts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateFlaggedPost(FlaggedPost flaggedPost)
        {
            flaggedPost.Active = true;
            flaggedPost.DateOfCreation = DateTimeOffset.Now;
            flaggedPost.LastUpdate = DateTimeOffset.Now;
            context.FlaggedPosts.Add(flaggedPost);
        }

        public void DeleteFlaggedPost(int flaggedPostId)
        {
            FlaggedPost favorite = context.FlaggedPosts.Find(flaggedPostId);
            context.FlaggedPosts.Remove(favorite);
        }

        public void UpdateFlaggedPost(FlaggedPost flaggedPost)
        {
            flaggedPost.LastUpdate = DateTimeOffset.Now;
            context.Entry(flaggedPost).State = EntityState.Modified;
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