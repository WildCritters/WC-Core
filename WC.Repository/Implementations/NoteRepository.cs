﻿using Microsoft.EntityFrameworkCore;
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
    public class NoteRepository : INoteRepository, IDisposable
    {
        private WildCrittersDBContext context;

        public NoteRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Note> GetNotes()
        {
            return context.Notes.ToList();
        }

        public Note GetNoteByID(int id)
        {
            return context.Notes.Find(id);
        }

        public void InsertNote(Note note)
        {
            context.Notes.Add(note);
        }

        public void DeleteNote(int noteId)
        {
            Note note = context.Notes.Find(noteId);
            context.Notes.Remove(note);
        }

        public void UpdateNote(Note note)
        {
            context.Entry(note).State = EntityState.Modified;
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
