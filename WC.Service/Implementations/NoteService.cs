using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;
using WC.Repository.Contracts;

namespace WC.Service.Implementations
{
    public class NoteService
    {
        private INoteRepository _repository;

        public NoteService(INoteRepository repository) 
        {
            this._repository = repository;
        }

        public IEnumerable<Note> GetNotes()
        {
            //return _repository.GetNotes();
            return new List<Note>();
        }
    }
}
