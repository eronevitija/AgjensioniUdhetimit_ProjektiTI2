using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AgjensioniUdhetimit_ProjektiTI2.Resources;


namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Staff : Base
    {
        public int StaffID { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }


        [Display(Name = "LastName", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "GenderRequired")]
        public string Gender { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "AddressRequired")]
        public string Address { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "EmailRequired")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "PhoneNumberRequired")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Birthdate", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "BirthdateRequired")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    
        public Staff(){}
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