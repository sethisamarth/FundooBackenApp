using BusinessLayer.Interfaces;
using CommonLayer.Model;
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
    }
}
        
   
