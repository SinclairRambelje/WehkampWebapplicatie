using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Database;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Logic
{
    public class FactuurRepository
    {
        public FactuurOracleContext FactuurOracleContext { get; set; }


        public FactuurRepository()
        {
            FactuurOracleContext = new FactuurOracleContext();
        }


        public List<Factuur> GetAll()
        {
            return FactuurOracleContext.GetAll();
        }

        

        public List<Factuur> GetbyID(int AccountID)
        {
            return FactuurOracleContext.GetbyID(AccountID);
        }

        
        public List<UNIEKPRODUCTGEKOCHT> GetAllFactuurProductenByID(int Factuurnummer)
        {
            return FactuurOracleContext.GetAllFactuurProductenByID(Factuurnummer);
        }


        public List<UNIEKPRODUCTGEKOCHT> GetAllUniekProducten()
        {
            throw new NotImplementedException();
        }


        public void AddFactuur(Factuur factuur)
        {
            FactuurOracleContext.AddFactuur(factuur);
        }

        public void AddUniekProductGekocht(UNIEKPRODUCTGEKOCHT Productgekocht)
        {
            FactuurOracleContext.AddUniekProductGekocht(Productgekocht);
        }

    }
}