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
               var Cd = this.context.NotesTable.Where(x => x.NotesId == collaborators.NotesId).SingleOrDefault();
                if(Cd != null)
                {
                    Collaborator newCollaborator = new Collaborator();
                    newCollaborator.NotesId = collaborators.NotesId;
                    newCollaborator.SenderEmail = collaborators.SenderEmail;
                    newCollaborator.ReceiverEmail = collaborators.ReceiverEmail;
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
    }
}

