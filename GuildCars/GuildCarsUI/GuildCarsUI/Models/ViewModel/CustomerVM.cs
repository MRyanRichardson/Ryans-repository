using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCarsUI.Models.ViewModel
{

    public class CustomerVM
    {
        public int VehicleId { get; set; }
        public string SalesAgent { get; set; }
        [Required(ErrorMessage = "Please enter the customer's name")]
        public string CustomerName { get; set; }
        [MaxLength(18, ErrorMessage = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the customer's address")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage = "Please enter the customer's city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please choose the customer's state")]
        public string StateId { get; set; }
        [Required(ErrorMessage = "Please enter the customer's ZIP code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter the purchase price")]
        [DataType(DataType.Currency)]
        public int PurchasePrice { get; set; }
        [Required(ErrorMessage = "Please choose the purchase type")]
        public int PurchaseTypeId { get; set; }
        public string PurchaseTypeName { get; set; }

    }
}