using CommonLayer.Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
       public bool AddCollaborator(CollaboratorModel collaborators, long Id);
       public bool DeleteCollaborator(long collaboratorId);
        IEnumerable<Collaborator> GetAllCollaborator();
    }
}
