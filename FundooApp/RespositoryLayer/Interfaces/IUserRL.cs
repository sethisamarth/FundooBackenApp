using CommonLayer.Model;
using FundooApp.Controllers.ResponseModel;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespositoryLayer.Interfaces
{
    public interface IUserRL
    {
       public bool Registration(UserRegistration user);
       public LoginResponse UserLogin(UserLogin user1);
        IEnumerable<User> GetAlldata();
       public bool SendResetLink(string email);
       public bool ResetPassword(ResetPassword resetPassword);
    }
}
