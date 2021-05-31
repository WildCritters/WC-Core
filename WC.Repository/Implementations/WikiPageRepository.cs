using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.Model;
using WC.Repository.Implementations;

namespace WC.Repository.Contracts
{
    public class WikiPageRepository : IWikiPageRepository
    {
        private readonly WildCrittersDBContext context;

        public WikiPageRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<WikiPage> GetWikiPages()
        {
            return context.WikiPages.ToList();
        }

        public WikiPage GetWikiPageById(int id)
        {
            return context.WikiPages.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateWikiPage(WikiPage wikiPage)
        {
            wikiPage.Active = true;
            wikiPage.DateOfCreation = DateTimeOffset.Now;
            wikiPage.LastUpdate = DateTimeOffset.Now;
            context.WikiPages.Add(wikiPage);
        }

        public void DeleteWikiPage(int wikiPageId)
        {
            WikiPage wikiPage = context.WikiPages.Find(wikiPageId);
            context.WikiPages.Remove(wikiPage);
        }

        public void UpdateWikiPage(WikiPage wikiPage)
        {
            wikiPage.LastUpdate = DateTimeOffset.Now;
            context.Entry(wikiPage).State = EntityState.Modified;
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