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
        public IEnumerable<User> GetAlldata()
        {
            return this.userRL.GetAlldata();
        }
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
