using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FourPatient.WebAPI.Models
{
    public class Patient
    {

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be 2 characters")]
        public string State { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter date in correct form")]
        public DateTime? DoB { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
