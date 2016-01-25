using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.Models
{
    public class Beoordeling
    {
        public int ID { get; set; }
        public int Product_ID { get; set; }
        public int Klantnummer { get; set; }
        public int Beoordelingcijfer { get; set; }
        public DateTime Datum { get; set; }
        public string Title { get; set; }
        public string Bericht { get; set; }
        public string Naam { get; set; }

        public Beoordeling(int id, int productId, int klantnummer, int beoordelingcijfer, DateTime datum, string title, string bericht)
        {
            ID = id;
            Product_ID = productId;
            Klantnummer = klantnummer;
            Beoordelingcijfer = beoordelingcijfer;
            Datum = datum;
            Title = title;
            Bericht = bericht;

            VerkrijgNaam();
        }

        public void VerkrijgNaam()
        {
            Naam = new AccountRepository().GetNameByID(this.Klantnummer);
        }
    }
}