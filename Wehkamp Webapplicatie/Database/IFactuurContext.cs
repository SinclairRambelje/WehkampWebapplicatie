using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Database
{
    public interface IFactuurContext
    {
        List<Factuur> GetAll();

        List<Factuur> GetbyID(int AccountID);

        List<UNIEKPRODUCTGEKOCHT> GetAllFactuurProductenByID(int Factuurnummer);

        List<UNIEKPRODUCTGEKOCHT> GetAllUniekProducten();

        void AddFactuur(Factuur factuur);

        void AddUniekProductGekocht(UNIEKPRODUCTGEKOCHT Productgekocht);
    }
}