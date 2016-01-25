using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Database
{
    public interface IProductContext
    {
        List<Product> GetAll();

        Product GetByID(int product_id);

        List<Product> GetBySubCategorieString(string subcategorienaam);

        List<Product> GetBySubCategorieStringLike(string subcategorienaam);

        List<Categorie> GetAllCategories();

        List<Betaalwijze> GetAllBetaalwijzes();

        List<Product> GetByNameLike(string naamLike);
    }

    
}