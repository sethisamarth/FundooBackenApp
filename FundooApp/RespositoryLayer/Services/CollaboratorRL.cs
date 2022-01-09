using CommonLayer.Model;
using RespositoryLayer.Context;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RespositoryLayer.Services
{
    public class CollaboratorRL:ICollaboratorRL
    {
        FundooContext context;
        public CollaboratorRL(FundooContext context)
        {
            this.context = context;
        }
        public bool AddCollaborator(CollaboratorModel collaborators)
        {
            try 
            {
               var Cd = this.context.NotesTable.Where(x => x.Id == collaborators.Id && x.NotesId == collaborators.NotesId ).SingleOrDefault();
               var Cd1 = this.context.Users.Where(x => x.EmailId == collaborators.EmailId).SingleOrDefault();
                if (Cd != null && Cd1!=null )
                {
                    Collaborator newCollaborator = new Collaborator();
                    newCollaborator.Id = collaborators.Id;
                    newCollaborator.NotesId = collaborators.NotesId;
                    newCollaborator.EmailId = collaborators.EmailId;
                    //Adding the data to database
                    this.context.CollaboratorTable.Add(newCollaborator);
                }
               
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
        public bool DeleteCollaborator(long collaboratorId)
        {
            try
            {
                if (collaboratorId > 0)
                {
                    var collaborator = this.context.CollaboratorTable.Where(x => x.CollaboratorId == collaboratorId).SingleOrDefault();
                    this.context.CollaboratorTable.Remove(collaborator);
                    this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Collaborator> GetAllCollaborator()
        {
            try
            {
                return this.context.CollaboratorTable.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

