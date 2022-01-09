using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;

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
        [HttpDelete]
        [Route("collaboratorId")]
        public IActionResult DeleteCollaborator(long collaboratorId)
        {
            try
            {
                bool result = this.collaboratorBL.DeleteCollaborator(collaboratorId);
                if (result.Equals(true))
                {
                    return this.Ok(new{ Status = true, Message = "Collaborator Deleted Sucessfully", Data = collaboratorId });
                }
                return this.BadRequest(new { Status = false, Message = "Unable to delete collaborator : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet("CollaboratorAllData")]
        public IActionResult GetAllData()
        {
            try
            {
                IEnumerable<Collaborator> collaborators = collaboratorBL.GetAllCollaborator();
                if (collaborators == null)
                {
                    return BadRequest(new { Success = false, message = "No collaborator Found" });
                }
                return Ok(new { Success = true, message = "  Retrieve Collaborator Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
