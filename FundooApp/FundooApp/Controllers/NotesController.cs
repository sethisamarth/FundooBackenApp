﻿using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RespositoryLayer.Context;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        private readonly IMemoryCache memoryCache;
        private readonly FundooContext context;
        private readonly IDistributedCache distributedCache;
        public NotesController(INotesBL notesBL, IMemoryCache memoryCache, FundooContext context, IDistributedCache distributedCache)
        {
            this.notesBL = notesBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this.context = context;
        }
        [HttpPost]
        public IActionResult CreateNote(NotesModel notes)
        {
            try
            {
               // long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (this.notesBL.CreateNote(notes))
                {
                    return this.Ok(new { Success = true, message = " note created successfully ",data = notes });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "unsuccessful Notes not Added" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Get all notes data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllNotesData()
        {
            try
            {
                IEnumerable<Notes> notes = notesBL.GetAllNotes();
                if (notes == null)
                {
                    return BadRequest(new { Success = false, message = "No Notes Found" });
                }
                return Ok(new { Success = true, message = " Successfully", data=notes });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Update Notes
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes( Notes notes)
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
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException =ex.InnerException});
            }
        }
        /// <summary>
        /// Delete Notes by NoteId
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
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
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }

        }
        /// <summary>
        /// Pin or unpin a note
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("pinOrUnpin")]
        public IActionResult PinOrUnpinNote(long noteId)
        {
            try
            {
                var result = this.notesBL.PinOrUnpin(noteId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "pinned successfully " });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Archieve or Unarchieve
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("archieveOrUnarchieve")]
        public IActionResult ArchieveOrUnarchieve(long noteId)
        {
            try
            {
                var result = this.notesBL.ArchieveOrUnArchieve(noteId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Archieved successfully " });

                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Add Color
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Color")]
        public IActionResult AddColor(long noteId, string color)
        {
            try
            {
                var result = this.notesBL.AddColor(noteId, color);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Add Colour Sucessfully", Data = color });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Trash Or Untrash
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("trashOrUntrash")]
        public IActionResult TrashOrUntrash(long noteId)
        {
            try
            {
                var result = this.notesBL.IsTrash(noteId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Retrieveing All TrashNotes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("retrieveAllTrashNotes")]
        public IActionResult RetrieveAllTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesBL.RetrieveTrashNotes();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieve Notes Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Adding Reminder
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="reminder"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("reminder")]
        public IActionResult AddReminder(long notesId,  string reminder)
        {
            try
            {
                bool result = this.notesBL.AddReminder(notesId, reminder);
                if (result.Equals("Remind added successfully"))
                {
                    return this.Ok(new { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new  { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Upload Image
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("uploadImage")]
        public IActionResult UploadImage(long noteId, IFormFile image)
        {
            try
            {
                bool result = this.notesBL.UploadImage(noteId, image);
                if (result.Equals(true))
                {
                    return this.Ok(new{ Status = true, Message = "Upload Image Successfully",Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Get all notes from Redis
        /// </summary>
        /// <returns></returns>
        [HttpGet("redis")]
        public async Task<IActionResult> GetAllNotesUsingRedisCache()
        {
            var cacheKey = "notesList";
            string serializedNotesList;
            var notesList = new List<Notes>();
            var redisNotesList = await distributedCache.GetAsync(cacheKey);
            if (redisNotesList != null)
            {
                serializedNotesList = Encoding.UTF8.GetString(redisNotesList);
                notesList = JsonConvert.DeserializeObject<List<Notes>>(serializedNotesList);
            }
            else
            {
                 notesList = (List<Notes>)notesBL.GetAllNotes();
                serializedNotesList = JsonConvert.SerializeObject(notesList);
                redisNotesList = Encoding.UTF8.GetBytes(serializedNotesList);
            }
            return Ok(notesList);
        }
        [HttpPut]
        [Route("edit")]
        public IActionResult NotesEdit(NewNotesModel model, long NotesId)
        {
            try
            {
                bool result = this.notesBL.EditNotes(model, NotesId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "update notes Sucessfully", data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to update notes : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}
