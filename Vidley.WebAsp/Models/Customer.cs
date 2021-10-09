using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidley.WebAsp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength((255))]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        
        [Display(Name="Date of Birth")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
    }

    public class UpdateCustomerDto
    {
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}