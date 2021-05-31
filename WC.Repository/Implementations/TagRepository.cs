using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.Model;
using WC.Repository.Contracts;

namespace WC.Repository.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly WildCrittersDBContext context;

        public TagRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tag> GetTags()
        {
            return context.Tags.ToList();
        }

        public Tag GetTagById(int id)
        {
            return context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateTag(Tag tag)
        {
            tag.Active = true;
            tag.DateOfCreation = DateTimeOffset.Now;
            tag.LastUpdate = DateTimeOffset.Now;
            context.Tags.Add(tag);
        }

        public void DeleteTag(int tagId)
        {
            Tag tag = context.Tags.Find(tagId);
            context.Tags.Remove(tag);
        }

        public void UpdateTag(Tag tag)
        {
            tag.LastUpdate = DateTimeOffset.Now;
            context.Entry(tag).State = EntityState.Modified;
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