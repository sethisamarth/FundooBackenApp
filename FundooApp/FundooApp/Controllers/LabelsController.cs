﻿using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelsBL labelsBL;
        public LabelsController(ILabelsBL labelsBL)
        {
            this.labelsBL = labelsBL;
        }
        [HttpPost]
        [Route("addLable")]
        public IActionResult AddLabels(LabelModel model)
        {
            try
            {
                bool result = this.labelsBL.AddLables(model);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Add Lable Sucessfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Lable" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("retrieveAllLables")]
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
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
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
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("updateLable")]
        public IActionResult UpdateLable(LabelModel model)
        {
            try
            {
                bool result = this.labelsBL.UpdateLabels(model);
                if (result.Equals("UPDATE LABLE SUCCESSFULL"))
                {
                    return this.Ok(new { Status = true, Message = result, Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating lables" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
