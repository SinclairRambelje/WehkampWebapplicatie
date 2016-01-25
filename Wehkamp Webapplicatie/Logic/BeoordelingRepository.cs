using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Database;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Logic
{
    public class BeoordelingRepository
    {
        public BeoordelingOracleContext BeoordelingOracleContext { get; set; }

        public BeoordelingRepository()
        {
            BeoordelingOracleContext = new BeoordelingOracleContext();
        }

        public List<Beoordeling> GetAll()
        {
            return BeoordelingOracleContext.GetAll();
        }

        public List<Beoordeling> GetByProductID(int product_ID)
        {
            return BeoordelingOracleContext.GetByProductID(product_ID);
        }

        public bool AddBeoordeling(Beoordeling beoordeling)
        {
            return BeoordelingOracleContext.AddBeoordeling(beoordeling);
        }
    }
}