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
    public class CommentRepository
    {
        private readonly WildCrittersDBContext context;

        public CommentRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return context.Comments.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateComment(Comment comment)
        {
            comment.Active = true;
            comment.DateOfCreation = DateTimeOffset.Now;
            comment.LastUpdate = DateTimeOffset.Now;
            context.Comments.Add(comment);
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = context.Comments.Find(commentId);
            context.Comments.Remove(comment);
        }

        public void UpdateComment(Comment comment)
        {
            comment.LastUpdate = DateTimeOffset.Now;
            context.Entry(comment).State = EntityState.Modified;
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
