using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Winkelmand
    {
        public List<Product> Producten { get; set; }

        public Winkelmand()
        {
            Producten = new List<Product>();
        }

        public decimal TotaalBedragAanContent()
        {
            decimal Totaal = 0;
            foreach (Product product in Producten)
            {
                Totaal += product.Prijs;
            }
            return Totaal;
        }
    }
}