using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.API.Model.Note;
using WC.DTO;
using WC.Service.Contracts;

namespace WC.API.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private INoteService service;
        public NoteController(INoteService service)
        {
            this.service = service;
        }

        [HttpGet("/{id}")]
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

        [HttpPost("/create")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(InsertNoteRequest request)
        {
            service.InsertNote(request.X, 
                request.Y, 
                request.Width, 
                request.Height, 
                request.Body, 
                request.IdPost);

            return Ok();
        }

        [HttpPut("/{id}/update")]
        public ActionResult Edit(int id, UpdateNoteRequest request)
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
                return StatusCode(500);
            }
        }

        [HttpDelete("/{id}/inactivate")]
        public ActionResult Inactivate(int id)
        {
            service.DeleteLogicNote(id);
            return Ok();
        }

        [HttpDelete("/{id}/delete")]
        public ActionResult Delete(int id)
        {
            service.DeleteNote(id);
            return Ok();
        }
    }
}
