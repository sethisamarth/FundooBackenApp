using BusinessLayer.Interfaces;
using CommonLayer.Model;
using FundooApp.Controllers.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL; 
        }
        [HttpPost]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Successful" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
        [HttpGet("UserInfo")]
        public IActionResult GetAlldata()
        {
            try
            {
                var userInfo = this.userBL.GetAlldata();
                if (userInfo != null)
                {
                    return this.Ok(new { Success = true, message = "User records found", userdata = userInfo });

                }
                return this.BadRequest(new { Success = false, message = " User records not found" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        [HttpPost("Login")]
        public IActionResult UserLogin(UserLogin user1)
        {
            try
            {
                LoginResponse result = this.userBL.UserLogin(user1);
                if (result.EmailId != null)
                {
                    return this.Ok(new { Success = true, message = "Login Successful", data = result });
                }
                return this.BadRequest(new { Success = false, message = "Login unsuccessful" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
    }
}
