using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Role : Base
    {
        public int RoleID { get; set; }
        public string  RoleDescription { get; set; }

        public Role() {  }

        public Role(int roleId, string roleDescription)
        {
            RoleID = roleId;
            RoleDescription = roleDescription;
        }


    }
}