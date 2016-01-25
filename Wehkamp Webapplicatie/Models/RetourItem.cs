using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class RetourItem
    {
        public int Product_ID { get; set; }

        public int Factuurnummer_ID { get; set; }

        public int Retourafspraak_ID { get; set; }

        public decimal TotaalBedrag { get; set; }

        public int Aantal { get; set; }

        public RetourItem(int productId, int factuurnummerId, int retourafspraakId, decimal totaalBedrag, int aantal)
        {
            Product_ID = productId;
            Factuurnummer_ID = factuurnummerId;
            Retourafspraak_ID = retourafspraakId;
            TotaalBedrag = totaalBedrag;
            Aantal = aantal;
        }

    }
}