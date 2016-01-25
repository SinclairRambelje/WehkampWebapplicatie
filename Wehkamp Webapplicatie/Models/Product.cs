using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Productnaam { get; set; }
        public decimal Prijs { get; set; }
        public string Sale { get; set; }
        public int Categorie_ID { get; set; }
        public int Voorraad { get; set; }
        public int Specificaties_ID { get; set; }

        public Product(int id, string productnaam, decimal prijs, string sale, int categorieId, int voorraad, int specificatiesId)
        {
            ID = id;
            Productnaam = productnaam;
            Prijs = prijs;
            Sale = sale;
            Categorie_ID = categorieId;
            Voorraad = voorraad;
            Specificaties_ID = specificatiesId;
        }
    }
}