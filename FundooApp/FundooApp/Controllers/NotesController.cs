using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes([FromBody] Notes notes)
        {
            try
            {
                var result = this.notesBL.UpdateNotes(notes);
                if (result.Equals("UPDATE SUCCESSFULL"))
                {
                    return this.Ok(new { Success = true, message = "Note Updated successfully " });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult DeleteNotes(long noteId)
        {
            try
            {
                var result = this.notesBL.RemoveNote(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Success = true, message = "Note Removed successfully " });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete note : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }

        }
    }
}
