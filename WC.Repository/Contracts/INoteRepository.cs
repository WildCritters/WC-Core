using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotes();
        Note GetNoteByID(int id);
        void InsertNote(Note note);
        void DeleteNote(int noteId);
        void UpdateNote(Note note);
        void Save();
    }
}
