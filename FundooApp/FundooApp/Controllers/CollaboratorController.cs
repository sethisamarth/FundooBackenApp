using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBL collaboratorBL;

        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
            this.collaboratorBL = collaboratorBL;
        }
        /// <summary>
        /// Adding Collaborator
        /// </summary>
        /// <param name="collaborators"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addCollaborators")]
        public ActionResult AddCollaborators(CollaboratorModel collaborators)
        {
            try
            {
                var Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.collaboratorBL.AddCollaborator(collaborators,Id))
                {
                    return this.Ok(new{ Status = true, Message = "New Collaborator Added Sucessfully", Data = collaborators });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Delete Collaborator
        /// </summary>
        /// <param name="collaboratorId"></param>
        /// <returns></returns>
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
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Get All collaborator
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                IEnumerable<Collaborator> collaborators = collaboratorBL.GetAllCollaborator();
                if (collaborators == null)
                {
                    return BadRequest(new { Success = false, message = "No collaborator Found" });
                }
                return Ok(new { Success = true, message = "  Retrieve Collaborator Successfully",data=collaborators });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}
