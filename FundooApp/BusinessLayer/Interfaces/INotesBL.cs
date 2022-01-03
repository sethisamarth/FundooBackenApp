using CommonLayer.Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface INotesBL
    {
        public bool CreateNote(NotesModel notes);
        IEnumerable<Notes> GetAllNotes();
        public bool RemoveNote(long noteId);
        public string UpdateNotes(Notes notes);
    }
}
