using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using AgjensioniUdhetimit_ProjektiTI2.Resources;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Client : Base
    {
        public int ClientID { get; set; }

        [Display(Name = "FirstName",ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType =typeof(Content),ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }


        [Display(Name = "LastName", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }


        [Display(Name = "Address", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "AddressRequired")]
        public string Address { get; set; }


        [Display(Name = "PhoneNumber", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "PhoneNumberRequired")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "EmailRequired")]
        public string Email { get; set; }

        public Client(){}

       public Client(int clientID, string firstName, string lastName, string address,  int phoneNumber, string email)
       {
            ClientID = clientID;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
       }

    }
}