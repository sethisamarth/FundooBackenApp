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
    public class LabelsController : ControllerBase
    {
        private readonly ILabelsBL labelsBL;
        public LabelsController(ILabelsBL labelsBL)
        {
            this.labelsBL = labelsBL;
        }
        /// <summary>
        /// Adding label
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addLable")]
        public IActionResult AddLabels(LabelModel model)
        {
            try
            {
                var Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                bool result = this.labelsBL.AddLables(model,Id);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Add Lable Sucessfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Lable" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Retrieveing all labels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetrieveAllLables()
        {
            try
            {
                IEnumerable<Labels> result = this.labelsBL.RetrieveLables();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieve Lables Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Lables" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="lableId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("lableId")]
        public IActionResult DeleteLable(long lableId)
        {
            try
            {
                bool result = this.labelsBL.RemoveLable(lableId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Delete Lable Sucessfully", Data = lableId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete lable : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult LableUpdate(LabelModel1 model,long labelId)
        {
            try
            {
                bool result = this.labelsBL.UpdateLabel(model, labelId);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "update Lable Sucessfully" ,data= model});
                }

                return this.BadRequest(new { Status = false, Message = "Unable to update lable : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}
