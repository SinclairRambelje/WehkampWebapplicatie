using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Merk
    {
        public int ID { get; set; }
        public string MerkNaam { get; set; }
        public string Beschrijving { get; set; }

        public Merk(int id, string merkNaam, string beschrijving)
        {
            ID = id;
            MerkNaam = merkNaam;
            Beschrijving = beschrijving;
        }
    }
}