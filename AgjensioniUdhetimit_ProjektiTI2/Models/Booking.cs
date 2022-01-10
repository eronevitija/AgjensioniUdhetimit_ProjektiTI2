using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgjensioniUdhetimit_ProjektiTI2.Resources;


namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Booking : Base
    {
        public int BookingID { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "NameRequired")]
        public string Name { get; set; }

        [Display(Name = "GoingFrom", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "GoingFromRequired")]
        public string GoingFrom { get; set; }

        [Display(Name = "GoingTo", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "GoingToRequired")]
        public string GoingTo { get; set; }

        [Display(Name = "DepartureDate", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "DepartureDateRequired")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "DayOfStaying", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "DayOfStayingRequired")]
        public string DayOfStaying { get; set; }

        [Display(Name = "HotelName", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "HotelNameRequired")]
        public string HotelName { get; set; }

        [Display(Name = "NumberOfRooms", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "NumberOfRoomsRequired")]
        public int NumberOfRooms { get; set; }

        [Display(Name = "NOPeople", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "NOPeopleRequired")]
        public int NOPeople { get; set; }

        public Booking(){}
        public Booking(int bookingID,string name,string lastName, 
            string goingFrom, string goingTo,  DateTime departureDate, string dayOfStaying, string hotelName,
            int noRooms, int noPeople)
        {
            BookingID = bookingID;
            Name = name;
            GoingFrom = goingFrom;
            GoingTo = goingTo;
            DepartureDate = departureDate;
            DayOfStaying = dayOfStaying;
            HotelName = hotelName;
            NumberOfRooms = noRooms;
            NOPeople = noPeople;
        }
    }
}