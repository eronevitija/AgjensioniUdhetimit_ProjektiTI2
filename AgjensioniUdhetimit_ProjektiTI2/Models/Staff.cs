using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Staff : Base
    {

        public int StaffID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    
        public Staff()
        {

        }
        public Staff(int staffID,string firstName,string lastName,string gender,
            string address,string email,int phoneNumber,DateTime birthDate)
        {
            StaffID = staffID;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            Birthdate = birthDate;
        }


    }
}