using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public class ForumTopicRepository : IForumTopicRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public ForumTopicRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<ForumTopic> GetForumTopics()
        {
            return context.ForumTopics.ToList();
        }

        public ForumTopic GetForumTopicById(int id)
        {
            return context.ForumTopics.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateForumTopic(ForumTopic forumTopic)
        {
            forumTopic.Active = true;
            forumTopic.DateOfCreation = DateTimeOffset.Now;
            forumTopic.LastUpdate = DateTimeOffset.Now;
            context.ForumTopics.Add(forumTopic);
        }

        public void DeleteForumTopic(int forumTopicId)
        {
            ForumTopic forumPost = context.ForumTopics.Find(forumTopicId);
            context.ForumTopics.Remove(forumPost);
        }

        public void UpdateForumTopic(ForumTopic forumTopic)
        {
            forumTopic.LastUpdate = DateTimeOffset.Now;
            context.Entry(forumTopic).State = EntityState.Modified;
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