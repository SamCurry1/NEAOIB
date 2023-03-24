using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NEAOIB.Models
{
    public class Account
    {
        [Key] 
        public int UserID { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="E-Mail is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Please confrm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}