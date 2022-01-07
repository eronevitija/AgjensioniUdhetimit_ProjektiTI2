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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string GoingFrom { get; set; }
        [Required]
        public string GoingTo { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int NOPeople { get; set; }

        public Booking()
        {

        }
        public Booking(int bookingID,string firstName,string lastName, string email,
            string goingFrom, string goingTo, DateTime arrivalDate, DateTime departureDate,
            int noPeople)
        {
            BookingID = bookingID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            GoingFrom = goingFrom;
            GoingTo = goingTo;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            NOPeople = noPeople;
        }

       

    }
}