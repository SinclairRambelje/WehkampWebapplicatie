using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Kleur
    {
        public int ID { get; set; }
        public string KleurNaam { get; set; }

        public Kleur(int id, string kleurNaam)
        {
            ID = id;
            KleurNaam = kleurNaam;
        }
    }
}