using CommonLayer.Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespositoryLayer.Interfaces
{
    public interface INotesRL
    {
        public bool CreateNote(NotesModel notes);
        IEnumerable<Notes> GetAllNotes();
        void DeleteNote(object noteId);
    }
}
