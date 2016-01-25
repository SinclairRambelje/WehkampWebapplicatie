using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Betaalwijze
    {
        public int ID { get; set; }
        public string Omschrijving { get; set; }

        public Betaalwijze(int id, string omschrijving)
        {
            ID = id;
            Omschrijving = omschrijving;
        }
    }
}