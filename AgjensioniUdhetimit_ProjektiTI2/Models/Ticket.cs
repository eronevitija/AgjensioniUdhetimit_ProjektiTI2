using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Ticket : Base
    {
        public int TicketID { get; set; }
        public int FlightID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Deadline { get; set; }
        public int Number { get; set; }
        public int BookingID { get; set; }

    }
}