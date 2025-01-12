﻿using CommonLayer.Model;
using FundooApp.Controllers.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RespositoryLayer.Context;
using RespositoryLayer.Entity;
using RespositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RespositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext context;
        IConfiguration _config;
        public UserRL(FundooContext context, IConfiguration config)
        {
            this.context = context;
            _config = config;
        }
        /// <summary>
        /// Registering user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Registration(UserRegistration user)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.EmailId = user.EmailId;
                newUser.Password = encryptpass(user.Password);
                newUser.Createat = DateTime.Now;

                this.context.Users.Add(newUser);

                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Retrieving All users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAlldata()
        {
            return context.Users.ToList();
        }
        public LoginResponse UserLogin(UserLogin user1)
        {
            try
            {
                User existingLogin = this.context.Users.Where(X => X.EmailId == user1.EmailId).FirstOrDefault();
                if (Decryptpass(existingLogin.Password) == user1.Password)
                {
                    LoginResponse login = new LoginResponse();
                    string token;
                    token = GenerateJWTToken(existingLogin.EmailId,existingLogin.Id);
                    login.Id = existingLogin.Id;
                    login.FirstName = existingLogin.FirstName;
                    login.LastName = existingLogin.LastName;
                    login.EmailId = existingLogin.EmailId;
                    login.Createat = existingLogin.Createat;
                    login.Modifiedat = existingLogin.Modifiedat;
                    login.token = token;
                    return login;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception )
            { 
                throw;
            }
        }
        /// <summary>
        /// Generating Token
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        private string GenerateJWTToken(string EmailId,long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Email,EmailId),
                new Claim("Id",Id.ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// Encrypting Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        /// <summary>
        /// Decrypting 
        /// </summary>
        /// <param name="encryptpwd"></param>
        /// <returns></returns>
        private string Decryptpass(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        /// <summary>
        /// Sending email Link
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool SendResetLink(string email)
        {
            try
            {
                User existingLogin = this.context.Users.Where(X => X.EmailId == email).FirstOrDefault();
                if (existingLogin.EmailId != null)
                {
                    var token = GenerateJWTToken(existingLogin.EmailId,existingLogin.Id);
                    new MsmqOperation().Sender(token);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Reseting Password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var Entries = this.context.Users.FirstOrDefault(x => x.EmailId == resetPassword.EmailId);
                if (Entries != null)
                {
                    if (resetPassword.Password == resetPassword.ConfirmPassword)
                    {
                        Entries.Password = encryptpass(resetPassword.Password);
                        this.context.Entry(Entries).State = EntityState.Modified;
                        this.context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
