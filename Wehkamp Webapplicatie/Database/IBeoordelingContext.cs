using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Database
{
    public interface IBeoordelingContext
    {
        List<Beoordeling> GetAll();

        List<Beoordeling> GetByProductID(int product_ID);

        bool AddBeoordeling(Beoordeling beoordeling);
    }
}