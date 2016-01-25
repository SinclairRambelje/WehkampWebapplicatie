using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class SoortArtikel
    {
        public int ID { get; set; }
        public string Beschrijving { get; set; }

        public SoortArtikel(int id, string beschrijving)
        {
            ID = id;
            Beschrijving = beschrijving;
        }
    }
}