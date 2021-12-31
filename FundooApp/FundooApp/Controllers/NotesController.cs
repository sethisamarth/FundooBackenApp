using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        [HttpPost]
        public IActionResult CreateNote(NotesModel notes)
        {
            try
            {
                if (this.notesBL.CreateNote(notes))
                {
                    return this.Ok(new { Success = true, message = " note created successfully " });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unsuccessful Notes not Added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.InnerException });
            }
        }
        [HttpGet("NotesAllData")]
        public IActionResult GetAllData()
        {
            try
            {
                IEnumerable<Notes> notes = notesBL.GetAllNotes();
                if (notes == null)
                {
                    return BadRequest(new { Success = false, message = "No Notes Found" });
                }
                return Ok(new { Success = true, message = " Successfully   ", notes });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("/{Id}")]
        public IActionResult DeleteNote([FromRoute] long NotesId)
        {
            try
            {
                notesBL.DeleteNote(NotesId);
                return Ok(new { Success = true, message = "Notes deleted Successful" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

    }

}
