using BusinessLayer.Interfaces;
using CommonLayer.Model;
using FundooApp.Controllers.ResponseModel;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.userRL.Registration(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets the alldata.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAlldata()
        {
            return this.userRL.GetAlldata();
        }
        /// <summary>
        /// Users the login.
        /// </summary>
        /// <param name="user1">The user1.</param>
        /// <returns></returns>
        public LoginResponse UserLogin(UserLogin user1)
        {
            try
            {
                return this.userRL.UserLogin(user1);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Sends the reset link.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public bool SendResetLink(string email)
        {
            try
            {    
                return this.userRL.SendResetLink( email);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                bool result = this.userRL.ResetPassword(resetPassword);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
