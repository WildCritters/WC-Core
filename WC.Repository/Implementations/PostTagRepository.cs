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
    public class PostTagRepository : IPostTagRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public PostTagRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<PostTag> GetPostTags()
        {
            return context.PostTags.ToList();
        }

        public PostTag GetPostTagById(int id)
        {
            return context.PostTags.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreatePostTag(PostTag postTag)
        {
            postTag.Active = true;
            postTag.DateOfCreation = DateTimeOffset.Now;
            postTag.LastUpdate = DateTimeOffset.Now;
            context.PostTags.Add(postTag);
        }

        public void DeletePostTag(int postTagId)
        {
            PostTag postTag = context.PostTags.Find(postTagId);
            context.PostTags.Remove(postTag);
        }

        public void UpdatePostTag(PostTag postTag)
        {
            postTag.LastUpdate = DateTimeOffset.Now;
            context.Entry(postTag).State = EntityState.Modified;
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
