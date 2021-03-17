using Microsoft.AspNetCore.Mvc;
using System;
using WC.API.Model.Note;
using WC.DTO;
using WC.Service.Contracts;

namespace WC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService service;
        public NoteController(INoteService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
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

        [HttpPost("create")]
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

        [HttpPut("{id}/update")]
        public ActionResult UpdateNote(int id, UpdateNoteRequest request)
        {
            try
            {
                service.UpdateNote(request.X,
                request.Y,
                request.Width,
                request.Height,
                request.Body,
                id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}/inactivate")]
        public ActionResult InactivateNote(int id)
        {
            service.DeleteLogicNote(id);
            return Ok();
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteNote(int id)
        {
            service.DeleteNote(id);
            return Ok();
        }
    }
}
