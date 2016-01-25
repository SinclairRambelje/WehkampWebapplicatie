using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Materiaal
    {
        public int ID { get; set; }
        public string Materiaalnaam { get; set; }

        public Materiaal(int id, string materiaalnaam)
        {
            ID = id;
            Materiaalnaam = materiaalnaam;
        }
    }
}