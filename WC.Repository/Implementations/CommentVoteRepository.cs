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
    public class CommentVoteRepository : ICommentVoteRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public CommentVoteRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<CommentVote> GetCommentVotes()
        {
            return context.CommentVotes.ToList();
        }

        public CommentVote GetCommentVoteById(int id)
        {
            return context.CommentVotes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateCommentVote(CommentVote commentVote)
        {
            commentVote.Active = true;
            commentVote.DateOfCreation = DateTimeOffset.Now;
            commentVote.LastUpdate = DateTimeOffset.Now;
            context.CommentVotes.Add(commentVote);
        }

        public void DeleteCommentVote(int commentVoteId)
        {
            CommentVote commentVote = context.CommentVotes.Find(commentVoteId);
            context.CommentVotes.Remove(commentVote);
        }

        public void UpdateCommentVote(CommentVote comment)
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
