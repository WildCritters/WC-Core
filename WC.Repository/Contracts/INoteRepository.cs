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
        Note GetNoteById(int id);
        void CreateNote(Note note);
        void DeleteNote(int noteId);
        void UpdateNote(Note note);
        void Save();
    }
}
