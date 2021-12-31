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

        public void DeleteNote(long notesId)
        {
            try
            {
                this.notesRL.DeleteNote(notesId);
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
    }
}
        
   
