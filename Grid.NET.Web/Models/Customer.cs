using System;
using System.ComponentModel;

namespace Grid.NET.Web.Models
{
    public class Customer
    {
        [DisplayName("Customer Id")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Current Balance")]
        public double CurrentBalance { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}