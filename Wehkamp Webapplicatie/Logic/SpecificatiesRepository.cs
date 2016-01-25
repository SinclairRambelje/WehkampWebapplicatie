using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Database;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Logic
{
    public class SpecificatiesRepository
    {
        public SpecificatiesOracleContext specificatiesOracleContext { get; set; }

        public SpecificatiesRepository()
        {
            specificatiesOracleContext = new SpecificatiesOracleContext();
        }

        public void GetAllSpecificatiesByID(int Specificaties_ID, out Genre genre, out Kleur kleur, out Kraagvorm kraagvorm, out Maat maat
            , out Materiaal materiaal, out Merk merk, out Platform platform, out SoortArtikel soortArtikel)
        {
            specificatiesOracleContext.GetAllSpecificatiesByID( Specificaties_ID, out genre, out kleur, out kraagvorm, out maat
            , out materiaal, out merk, out platform, out soortArtikel);
        }
    }
}