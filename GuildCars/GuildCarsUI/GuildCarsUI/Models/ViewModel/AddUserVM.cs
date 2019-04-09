using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GuildCarsUI.Models.ViewModel
{
    public class AddUserVM
    {
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
        [Required(ErrorMessage = "Please enter the user's password")]
        [MinLength(5, ErrorMessage = "Passwords must be at least 5 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match")]
        [Required(ErrorMessage = "Please confirm the user's password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Roles { get; set; }
    }
}