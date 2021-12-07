using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    public class Base
    {
        public string InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdateNumber { get; set; }
    }
}