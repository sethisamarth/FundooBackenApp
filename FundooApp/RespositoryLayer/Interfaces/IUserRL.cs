using CommonLayer.Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool Registration(UserRegistration user);
        bool GetLogin(UserLogin user1);
        IEnumerable<User> GetAlldata();
    }
}
