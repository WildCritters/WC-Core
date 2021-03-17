using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;

namespace WC.Service.Contracts
{
    public interface INoteService
    {
        IEnumerable<Note> GetNotes();
        Note GetNoteById(int id);
        void CreateNote(int x, int y, int width, int height, string body, int idPost);
        void DeleteLogicNote(int noteId);
        void DeleteNote(int noteId);
        void UpdateNote(int x, int y, int width, int height, string body, int noteId);
    }
}
