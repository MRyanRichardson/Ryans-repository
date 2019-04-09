using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace GuildCarsUI.Models.ViewModel
{
    public class PasswordVM
    {
            public string UserId { get; set; }
            [Required(ErrorMessage = "Please enter your old password")]
            [DataType(DataType.Password)]
            public string OldPassword { get; set; }
            [Required(ErrorMessage = "Please enter your new password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
            [Required(ErrorMessage = "Please confirm your new password")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }
    }
}