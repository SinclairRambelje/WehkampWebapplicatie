using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Database;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Logic
{
    public class ProductRepository
    {
        public ProductOracleContext productOracleContext { get; set; }

        public ProductRepository()
        {
            productOracleContext = new ProductOracleContext();
        }

        public List<Product> GetBySubCategorieString(string subcategorienaam)
        {
            return productOracleContext.GetBySubCategorieString(subcategorienaam);
        }

        public List<Betaalwijze> GetAllBetaalwijzes()
        {
            return productOracleContext.GetAllBetaalwijzes();
        }

        public Product GetByID(int product_id)
        {
            return productOracleContext.GetByID(product_id);
        }

        public List<Product> GetByNameLike(string naamLike)
        {
            return productOracleContext.GetByNameLike(naamLike);
        }

        public List<Product> GetBySubCategorieStringLike(string subcategorienaam)
        {
            return productOracleContext.GetBySubCategorieStringLike(subcategorienaam);
        }
    }
}