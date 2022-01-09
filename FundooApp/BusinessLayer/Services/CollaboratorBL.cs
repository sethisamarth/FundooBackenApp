using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CollaboratorBL : ICollaboratorBL
    {
        ICollaboratorRL collaboratorRL;
        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.collaboratorRL = collaboratorRL;
        }

        public bool AddCollaborator(CollaboratorModel collaborators)
        {
            try
            {
                return this.collaboratorRL.AddCollaborator(collaborators);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public bool DeleteCollaborator(long collaboratorId)
        {
            try
            {
                return this.collaboratorRL.DeleteCollaborator(collaboratorId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<Collaborator> GetAllCollaborator()
        {
            try
            {
                return this.collaboratorRL.GetAllCollaborator();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
