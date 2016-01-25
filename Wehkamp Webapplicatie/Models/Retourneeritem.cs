using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Retourneeritem
    {
        public Product Product { get; set; }
        public int Factuurnummer_ID { get; set; }

        public Retourneeritem(Product product, int factuurnummerId)
        {
            Product = product;
            Factuurnummer_ID = factuurnummerId;
        }
    }
}