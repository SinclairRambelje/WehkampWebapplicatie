using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Factuur
    {
        public int Factuurnummer { get; set; }
        public string Klant_ID { get; set; }
        public string Betaalwijze_ID { get; set; }
        public string Afhaalpunt_ID { get; set; }
        public DateTime FactuurDatum { get; set; }

        public Factuur(int factuurnummer, string klantId, string betaalwijzeId, string afhaalpuntId, DateTime factuurDatum)
        {
            Factuurnummer = factuurnummer;
            Klant_ID = klantId;
            Betaalwijze_ID = betaalwijzeId;
            Afhaalpunt_ID = afhaalpuntId;
            FactuurDatum = factuurDatum;
        }
    }
}