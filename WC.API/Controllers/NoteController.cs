using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET: NoteController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: NoteController/Details/5
        [HttpGet("/{id}")]
        public Note GetNoteById(int id)
        {
            return service.GetNoteById(id);
        }

        // GET: NoteController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: NoteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: NoteController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: NoteController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: NoteController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: NoteController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
