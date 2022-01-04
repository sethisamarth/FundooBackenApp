﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class ResetPassword
    {

        [Required(ErrorMessage = "EmailId is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmaiId:")]

        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password contain six Character")]
        public string Password { get; set; }


        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword:")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "ConfirmPassword contain six Character")]
        public string ConfirmPassword { get; set;}
    }
}
