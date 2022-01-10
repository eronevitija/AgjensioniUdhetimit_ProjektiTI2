using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AgjensioniUdhetimit_ProjektiTI2.Resources;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Ticket : Base
    {
        public int TicketID { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }



        [Display(Name = "DateCreated", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "DateCreatedRequired")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Deadline", ResourceType = typeof(Content))]
        [Required(ErrorMessageResourceType = typeof(Content), ErrorMessageResourceName = "DeadlineRequired")]
        public string Deadline { get; set; }
        

        public Ticket(){}
        public Ticket(int ticketID,string firstName , string lastName ,DateTime dateCreated,
            string deadline)
        {
            TicketID = ticketID;
            FirstName = firstName;
            LastName = lastName;
            DateCreated = dateCreated;
            Deadline = deadline;
        }
    }
}