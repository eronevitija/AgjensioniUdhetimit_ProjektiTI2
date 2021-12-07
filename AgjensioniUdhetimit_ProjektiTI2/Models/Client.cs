using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Client : Base
    {
        public int ClientID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public Client()
        {

        }

        public Client(int clientId,string firstName,string lastName,string address,
                      int phoneNumber,string email)
        {
            ClientID = clientId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;

        }
        public Client(string firstName, string lastName, string address,
                      int phoneNumber,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Client(string firstName, string lastName, string address, 
                      int phoneNumber, string email,string insertBy,DateTime insertDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            InsertBy = insertBy;
            InsertDate = insertDate;
        }

        
    }
}