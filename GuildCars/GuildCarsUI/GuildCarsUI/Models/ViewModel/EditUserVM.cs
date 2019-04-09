
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsUI.Models.ViewModel
{
  
    public class EditUserVM
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Please enter the user's first name")]
        [MaxLength(128, ErrorMessage = "First name cannot exceed 128 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the user's last name")]
        [MaxLength(128, ErrorMessage = "Last name cannot exceed 128 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the user's email address")]
        [MaxLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please choose a role for this user")]
        public string RoleName { get; set; }
        [MinLength(5, ErrorMessage = "Passwords must be at least 5 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}