using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class UNIEKPRODUCTGEKOCHT
    {
        public int ID { get; set; }
        public int Product_ID { get; set; }
        public int Factuurnummer_ID { get; set; }
        public int Aantal { get; set; }
        public decimal TotaalBedrag { get; set; }

        public UNIEKPRODUCTGEKOCHT(int id, int productId, int factuurnummerId, int aantal, decimal totaalBedrag)
        {
            ID = id;
            Product_ID = productId;
            Factuurnummer_ID = factuurnummerId;
            Aantal = aantal;
            TotaalBedrag = totaalBedrag;
        }
    }
}