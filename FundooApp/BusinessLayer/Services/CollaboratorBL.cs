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
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborators">The collaborators.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public bool AddCollaborator(CollaboratorModel collaborators, long Id)
        {
            try
            {
                return this.collaboratorRL.AddCollaborator(collaborators,Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="collaboratorId">The collaborator identifier.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Gets all collaborator.
        /// </summary>
        /// <returns></returns>
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
