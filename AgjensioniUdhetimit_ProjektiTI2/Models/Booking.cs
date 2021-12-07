using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Booking : Base
    {
        public int BookingID { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public int ClientID { get; set; }

        public Booking()
        {

        }

        public Booking(int bookingID,DateTime bookingDate,int clientID)
        {
            BookingID = bookingID;
            BookingDate = bookingDate;
            ClientID = clientID;
        }

        public Booking(DateTime bookingDate, int clientID)
        {
            BookingDate = bookingDate;
            ClientID = clientID;
        }

        public Booking(DateTime bookingDate, int clientID, string insertBy, DateTime insertDate)
        {
            BookingDate = bookingDate;
            ClientID = clientID;
            InsertBy = insertBy;
            InsertDate = insertDate;
        }

    }
}