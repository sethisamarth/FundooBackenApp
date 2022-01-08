using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CollaboratorModel
    {
       // public long CollaboratorId { get; set; }
        public long NotesId { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
    }
}
