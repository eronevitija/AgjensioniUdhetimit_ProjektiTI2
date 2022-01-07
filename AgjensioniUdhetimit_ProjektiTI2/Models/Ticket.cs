using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Ticket : Base
    {
        
        public int TicketID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int FlightID { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string Deadline { get; set; }
        
        //public int BookingID { get; set; }

        public Ticket()
        {

        }

        public Ticket(int ticketID,string firstName , string lastName ,DateTime dateCreated, string deadline
            )
        {
            TicketID = ticketID;
            FirstName = firstName;
            LastName = lastName;
            DateCreated = dateCreated;
            Deadline = deadline;
        }
    }
}