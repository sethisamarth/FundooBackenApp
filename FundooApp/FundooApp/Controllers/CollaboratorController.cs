using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryLayer.Entity;
using System;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBL collaboratorBL;

        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
            this.collaboratorBL = collaboratorBL;
        }
        [HttpPost]
        [Route("addCollaborators")]
        public ActionResult AddCollaborators(CollaboratorModel collaborators)
        {
            try
            {
               // var result = this.collaboratorBL.AddCollaborator(collaborators);
                if (this.collaboratorBL.AddCollaborator(collaborators))
                {
                    return this.Ok(new{ Status = true, Message = "New Collaborator Added Sucessfully", Data = collaborators });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
