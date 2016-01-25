using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Kraagvorm
    {
        public int ID { get; set; }
        public string KraagvormMaat { get; set; }

        public Kraagvorm(int id, string kraagvormMaat)
        {
            ID = id;
            KraagvormMaat = kraagvormMaat;
        }
    }
}