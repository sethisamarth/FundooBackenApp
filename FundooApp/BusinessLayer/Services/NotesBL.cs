using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        INotesRL notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }
        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        public bool CreateNote(NotesModel notes)
        {
            try
            {
                return this.notesRL.CreateNote(notes);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Notes> GetAllNotes()
        {
            try
            {
                return this.notesRL.GetAllNotes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ex.Message</exception>
        public bool RemoveNote(long noteId)
        {
            try
            {
                bool result = this.notesRL.RemoveNote(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string UpdateNotes(Notes notes)
        {
            try
            {
                string result = this.notesRL.UpdateNotes(notes);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Pins the or unpin.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string PinOrUnpin(long noteId)
        {
            try
            {
                string result = this.notesRL.PinOrUnpin(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Archieves the or un archieve.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string ArchieveOrUnArchieve(long noteId)
        {
            try
            {
                string result = this.notesRL.ArchieveOrUnarchieve(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Adds the color.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddColor(long noteId, string color)
        {
            try
            {
                bool result = this.notesRL.AddColour(noteId, color);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Determines whether the specified note identifier is trash.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string IsTrash(long noteId)
        {
            try
            {
                string result = this.notesRL.IsTrash(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public IEnumerable<NotesModel> RetrieveTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesRL.RetrieveTrashNotes();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddReminder(long notesId, string reminder)
        {
            try
            {
                bool result = this.notesRL.AddReminder(notesId, reminder);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool UploadImage(long noteId, IFormFile image)
        {
            try
            {
                bool result = this.notesRL.UploadImage(noteId, image);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EditNotes(NewNotesModel model, long notesId)
        {

            try
            {
                bool result = this.notesRL.EditNotes( model,  notesId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
        
   
