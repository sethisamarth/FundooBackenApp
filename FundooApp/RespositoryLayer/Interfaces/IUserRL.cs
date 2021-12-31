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
        bool Registration(UserRegistration user);
        LoginResponse UserLogin(UserLogin user1);
        IEnumerable<User> GetAlldata();
    }
}
