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
    public class NoteVersionRepository : INoteVersionRepository
    {
        private readonly WildCrittersDBContext context;

        public NoteVersionRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<NoteVersion> GetNoteVersions()
        {
            return context.NoteVersion.ToList();
        }

        public NoteVersion GetNoteVersionById(int id)
        {
            return context.NoteVersion.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateNoteVersion(NoteVersion noteVersion)
        {
            noteVersion.Active = true;
            noteVersion.DateOfCreation = DateTimeOffset.Now;
            noteVersion.LastUpdate = DateTimeOffset.Now;
            context.NoteVersion.Add(noteVersion);
        }

        public void DeleteNoteVersion(int noteVersionId)
        {
            NoteVersion noteVersion = context.NoteVersion.Find(noteVersionId);
            context.NoteVersion.Remove(noteVersion);
        }

        public void UpdateNoteVersion(NoteVersion noteVersion)
        {
            noteVersion.LastUpdate = DateTimeOffset.Now;
            context.Entry(noteVersion).State = EntityState.Modified;
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
