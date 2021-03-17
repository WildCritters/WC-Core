using AutoMapper;
using System.Collections.Generic;
using WC.DTO;
using WC.Repository.Contracts;
using WC.Service.Contracts;

namespace WC.Service.Implementations
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;
        private readonly IMapper mapper;

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

        public void CreateNote(int x, int y, int width, int height, string body, int postId)
        {
            Note model = new()
            {
                X = x,
                Y = y,
                Width = width,
                Height = height,
                Body = body,
                Version = 1,
                PostId = postId
            };

            _repository.CreateNote(mapper.Map<Note, Model.Note>(model));
            _repository.Save();
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
