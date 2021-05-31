using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface INoteVersionRepository
    {
        IEnumerable<NoteVersion> GetNoteVersions();
        NoteVersion GetNoteVersionById(int id);
        void CreateNoteVersion(NoteVersion note);
        void DeleteNoteVersion(int noteId);
        void UpdateNoteVersion(NoteVersion note);
        void Save();
    }
}
