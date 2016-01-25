using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Subgenre
    {
        public int ID { get; set; }
        public string SubgenreNaam { get; set; }

        public Subgenre(int id, string subgenreNaam)
        {
            ID = id;
            SubgenreNaam = subgenreNaam;
        }
    }
}