using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class RetourAfspraak
    {
        public int ID { get; set; }
        public int Klant_ID { get; set; }
    public DateTime Datum { get; set; }

        public RetourAfspraak(int id, int klantId, DateTime datum)
        {
            ID = id;
            Klant_ID = klantId;
            Datum = datum;
        }
    }
}