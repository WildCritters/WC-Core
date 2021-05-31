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
    public class PostRepository : IPostRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public PostRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Post> GetPosts()
        {
            return context.Posts.ToList();
        }

        public Post GetPostById(int id)
        {
            return context.Posts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreatePost(Post post)
        {
            post.Active = true;
            post.DateOfCreation = DateTimeOffset.Now;
            post.LastUpdate = DateTimeOffset.Now;
            context.Posts.Add(post);
        }

        public void DeletePost(int postId)
        {
            Post post = context.Posts.Find(postId);
            context.Posts.Remove(post);
        }

        public void UpdatePost(Post post)
        {
            post.LastUpdate = DateTimeOffset.Now;
            context.Entry(post).State = EntityState.Modified;
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
