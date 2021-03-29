using Microsoft.AspNetCore.Mvc;
using System;
using WC.API.Model.Note;
using WC.DTO;
using WC.Service.Contracts;

namespace WC.API.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService service;
        public NoteController(INoteService service)
        {
            this.service = service;
        }

        [HttpGet("{id}", Name = "GetNotesById")]
        public Note GetNoteById(int id)
        {
            return service.GetNoteById(id);
        }

        [HttpGet]
        public GetNotesResponse GetNotes()
        {
            return new GetNotesResponse()
            {
                Notes = service.GetNotes()
            };
        }

        [HttpPost]
        public ActionResult CreateNote(InsertNoteRequest request)
        {
            service.CreateNote(request.X,
                request.Y,
                request.Width,
                request.Height,
                request.Body,
                request.IdPost);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateNote(UpdateNoteRequest request)
        {
            try
            {
                service.UpdateNote(request.X,
                request.Y,
                request.Width,
                request.Height,
                request.Body,
                request.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}/inactivate", Name = "Inactivate")]
        public ActionResult InactivateNote(int id)
        {
            service.DeleteLogicNote(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteNote(int id)
        {
            service.DeleteNote(id);
            return Ok();
        }
    }
}
