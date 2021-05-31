using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public class ForumPostRepository : IForumPostRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public ForumPostRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<ForumPost> GetForumPosts()
        {
            return context.ForumPosts.ToList();
        }

        public ForumPost GetForumPostById(int id)
        {
            return context.ForumPosts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateForumPost(ForumPost forumPost)
        {
            forumPost.Active = true;
            forumPost.DateOfCreation = DateTimeOffset.Now;
            forumPost.LastUpdate = DateTimeOffset.Now;
            context.ForumPosts.Add(forumPost);
        }

        public void DeleteForumPost(int forumPostId)
        {
            ForumPost forumPost = context.ForumPosts.Find(forumPostId);
            context.ForumPosts.Remove(forumPost);
        }

        public void UpdateForumPost(ForumPost forumPost)
        {
            forumPost.LastUpdate = DateTimeOffset.Now;
            context.Entry(forumPost).State = EntityState.Modified;
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