using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RespositoryLayer.Context;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RespositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        FundooContext context;
        IConfiguration configuration;
        public NotesRL(FundooContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        /// <summary>
        /// Create Notes
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        public bool CreateNote(NotesModel notes)
        {
            try
            {
                Notes newNotes = new Notes();
                newNotes.Id = notes.Id;
                newNotes.Title = notes.Title;
                newNotes.Message = notes.Message;
                newNotes.Reminder = notes.Reminder;
                newNotes.Colour = notes.Colour;
                newNotes.Image = notes.Image;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsPin = notes.IsPin;
                newNotes.IsTrash = notes.IsTrash;
                newNotes.Createdat = DateTime.Now;
                //Adding the data to database
                this.context.NotesTable.Add(newNotes);
                //Save the changes in database
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
        /// <summary>
        /// Get All Notes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Notes> GetAllNotes()
        {
            try
            {
                return this.context.NotesTable.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Remove Notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool RemoveNote(long noteId)
        {
            try
            {
                if (noteId > 0)
                {
                    var notes = this.context.NotesTable.Where(x => x.NotesId == noteId).SingleOrDefault();
                    if (notes != null)
                    {
                            this.context.NotesTable.Remove(notes);
                            this.context.SaveChangesAsync();
                            return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update Notes
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string UpdateNotes(Notes notes)
        {
            try
            {
                if (notes.NotesId != 0)
                {
                    this.context.Entry(notes).State = EntityState.Modified;
                    this.context.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }
                return "Updation Failed";
            }
            catch (Exception )
            {
                throw;
            }
        }
        /// <summary>
        /// Pin or Unpin Notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string PinOrUnpin(long noteId)
        {
            try
            {
                var notes = this.context.NotesTable.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes.IsPin == false)
                {
                    notes.IsPin = true;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note is getting pin";
                    return message;
                }
                if (notes.IsPin == true)
                {
                    notes.IsPin = false;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note Unpinned";
                    return message;
                }
                return "Unable to Pin or Unpin notes";
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Archieve Or Unarchieve
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ArchieveOrUnarchieve(long noteId)
        {
            try
            {
                var notes = this.context.NotesTable.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes.IsArchive == false)
                {
                    notes.IsArchive = true;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note is Archieve";
                    return message;
                }
                if (notes.IsArchive == true)
                {
                    notes.IsArchive = false;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note UnArchieve";
                    return message;
                }
                return "Unable to Archieve or UnArchieve notes";
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Add color
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddColour(long noteId, string color)
        {
            try
            {
                var notes = this.context.NotesTable.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    notes.Colour = color;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Trashing Notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string IsTrash(long noteId)
        {
            try
            {
                var notes = this.context.NotesTable.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes.IsTrash == false)
                {
                    notes.IsTrash = true;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Notes Is Trashed";
                    return message;
                }
                if (notes.IsTrash == true)
                {
                    notes.IsTrash = false;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    string message = "Note Restored";
                    return message;
                }

                return "Unable to Trash or Restored notes"; ;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Retrieving Trash Notes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = (IEnumerable<NotesModel>)this.context.NotesTable.Where(x => x.IsTrash == true).ToList();
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }
                return result; 
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Adding Reminder
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="reminder"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddReminder(long notesId, string reminder)
        {
            try
            {
                var notes = this.context.NotesTable.Where(x => x.NotesId == notesId).FirstOrDefault();
                if (notes != null)
                {
                    notes.Reminder = reminder;
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false ;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Upload Image for note
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="noteimage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UploadImage(long noteId, IFormFile noteimage)
        {
            try
            {
                var notes = this.context.NotesTable.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    Account account = new Account
                    (
                        configuration["CloudinaryAccount:CloudName"],
                        configuration["CloudinaryAccount:ApiKey"],
                        configuration["CloudinaryAccount:ApiSecret"]
                    );
                    var path = noteimage.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(noteimage.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    notes.Image = uploadResult.Url.ToString();
                    context.Entry(notes).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public bool EditNotes(NewNotesModel model ,long NotesId)
        {
            try
            {
                var note = this.context.NotesTable.Where(x => x.NotesId == NotesId).SingleOrDefault();
                if (note != null)
                {
                    note.Title = model.Title;
                    note.Message=model.Message;
                    this.context.Update(note);
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
