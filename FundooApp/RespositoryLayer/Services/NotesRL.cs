using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
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
        public NotesRL(FundooContext context)
        {
            this.context = context;
        }
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
            catch (Exception e)
            {
                throw e;
            }
        }

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Pin and Unpin
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
