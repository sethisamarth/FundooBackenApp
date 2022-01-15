using BusinessLayer.Interfaces;
using CommonLayer.Model;
using FundooApp.Controllers.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RespositoryLayer.Context;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        private readonly IMemoryCache memoryCache;
        private readonly FundooContext context;
        private readonly IDistributedCache distributedCache;
        public UserController(IUserBL userBL, IMemoryCache memoryCache, FundooContext context, IDistributedCache distributedCache)
        {
            this.userBL = userBL; 
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this.context = context;
        }
        /// <summary>
        /// Registering User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Successful" ,data = user});
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Getting Users info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUserdata()
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
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// User login
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Forget Password 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("forgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email should not be null or empty");
            }
            try
            {
                if (this.userBL.SendResetLink(email))
                {
                    return Ok(new { Success = true, message = "Reset password link send successfully" });
                }
                else
                {
                    return Ok(new { Success = true, message = "Error in Reset password link send" });
                }
            }
            catch(Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("resetPassword")]
        public IActionResult ResetPasswordEmployee(ResetPassword resetPassword)
        {
            try
            {
                var result = this.userBL.ResetPassword(resetPassword);
                if (result.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Reset Password  Sucessfully", Data = resetPassword });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to reset password:Email not exist in database or password is not matched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllUsersUsingRedisCache()
        {
            var cacheKey = "UserList";
            string serializedUserList;
            var UserList = new List<User>();
            var redisUserList = await distributedCache.GetAsync(cacheKey);
            if (redisUserList != null)
            {
                serializedUserList = Encoding.UTF8.GetString(redisUserList);
                UserList = JsonConvert.DeserializeObject<List<User>>(serializedUserList);
            }
            else
            {
                UserList = await context.Users.ToListAsync();
                serializedUserList = JsonConvert.SerializeObject(UserList);
                redisUserList = Encoding.UTF8.GetBytes(serializedUserList);
                UserList = (List<User>)userBL.GetAlldata();
            }
            return Ok(UserList);
        }
    }
}
