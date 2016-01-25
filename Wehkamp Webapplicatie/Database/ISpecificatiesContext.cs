using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Database
{
    public interface ISpecificatiesContext
    {
        void GetAllSpecificatiesByID(int Specificaties_ID, out Genre genre, out Kleur kleur, out Kraagvorm kraagvorm,out Maat maat
            , out Materiaal materiaal, out Merk merk, out Platform platform, out SoortArtikel soortArtikel);

        List<Specificatie> GetAll();
    }
}