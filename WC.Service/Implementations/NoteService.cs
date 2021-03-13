using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;
using WC.Repository.Contracts;
using WC.Service.Contracts;

namespace WC.Service.Implementations
{
    public class NoteService : INoteService
    {
        private INoteRepository _repository;
        private IMapper mapper;

        public NoteService(INoteRepository repository, IMapper mapper) 
        {
            this._repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<Note> GetNotes()
        {
            return mapper.Map<IEnumerable<Model.Note>,IEnumerable<Note>>(_repository.GetNotes());
        }

        public Note GetNoteById(int id)
        {
            return mapper.Map<Model.Note, Note>(_repository.GetNoteById(id));
        }

        public void InsertNote(int x, int y, int width, int height, string body, int idPost)
        {
            Note model = new Note()
            {
                X = x,
                Y = y,
                Width = width,
                Height = height,
                Body = body,
                Version = 1,
                IdPost = idPost
            };

            _repository.InsertNote(mapper.Map<Note, Model.Note>(model));
        }

        public void DeleteLogicNote(int noteId)
        {
            Note note = mapper.Map<Model.Note, Note>(_repository.GetNoteById(noteId));
            note.Active = false;
            _repository.UpdateNote(mapper.Map<Note, Model.Note>(note));
            _repository.Save();
        }

        public void DeleteNote(int noteId)
        {
            _repository.DeleteNote(noteId);
            _repository.Save();
        }

        public void UpdateNote(int x, int y, int width, int height, string body, int noteId)
        {
            Note note = mapper.Map<Model.Note, Note>(_repository.GetNoteById(noteId));
            note.X = x;
            note.Y = y;
            note.Width = width;
            note.Height = height;
            note.Body = body;

            _repository.UpdateNote(mapper.Map<Note, Model.Note>(note));
            _repository.Save();
        }
    }
}
