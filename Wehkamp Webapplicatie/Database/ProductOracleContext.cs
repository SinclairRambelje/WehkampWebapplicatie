using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;
using Oracle.ManagedDataAccess.Client;

namespace Wehkamp_Webapplicatie.Database
{
    public class ProductOracleContext : IProductContext
    {
        //krijg alle producten uit DB
        public List<Product> GetAll()
        {
            List<Product> producten = new List<Product>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from product");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product(Convert.ToInt32(reader["ID"]),
                                reader["productnaam"].ToString(), Convert.ToDecimal(reader["prijs"]),
                                reader["sale"].ToString()
                                , Convert.ToInt32(reader["categorie_Id"]), Convert.ToInt32(reader["voorraad"]),
                                Convert.ToInt32(reader["Specificaties_ID"]));
                            producten.Add(product);
                        }
                    }
                }
            }
            return producten;
        }

        //krijg product op basis van product id
        public Product GetByID(int product_id)
        {
            return GetAll().Find(item => item.ID == product_id);
        }

        //krijg alle producten op categorienaam 
        public List<Product> GetBySubCategorieString(string subcategorienaam)
        {
            return
                GetAll()
                    .FindAll(
                        product =>
                            product.Categorie_ID ==
                            GetAllCategories().Find(item => item.Categorienaam == subcategorienaam).ID);
        }

        //krijg alle producten op categorienaam wildcard stijl
        public List<Product> GetBySubCategorieStringLike(string subcategorienaam)
        {
            try
            {
                return
               GetAll()
                   .FindAll(
                       product =>
                           product.Categorie_ID ==
                           GetAllCategories().Find(item => item.Categorienaam.Contains(subcategorienaam)).ID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //krijg alle categorieen
        public List<Categorie> GetAllCategories()
        {
            List<Categorie> categories = new List<Categorie>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from Categorie");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categorie categorie = new Categorie(Convert.ToInt32(reader["ID"]),
                                reader["SubCategorie_ID"].ToString(), reader["categorienaam"].ToString()
                                );
                            categories.Add(categorie);
                        }
                    }
                }
            }
            return categories;
        }

        //krijg alle betaalwijzes
        public List<Betaalwijze> GetAllBetaalwijzes()
        {
            List<Betaalwijze> betaalwijzes = new List<Betaalwijze>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from betaalwijze");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Betaalwijze betaalwijze = new Betaalwijze(Convert.ToInt32(reader["ID"]),
                                reader["omschrijving"].ToString());
                            betaalwijzes.Add(betaalwijze);
                        }
                    }
                }
            }
            return betaalwijzes;
        }

        //krijg producten op naam wat lijkt op ingevoerde string
        public List<Product> GetByNameLike(string naamLike)
        {
            List<Product> GevondenProducten = new List<Product>();
            foreach (Product product in GetAll())
            {
                if (product.Productnaam.Contains(naamLike))
                {
                    GevondenProducten.Add(product);
                }
            }
            return GevondenProducten;
        }
    }


    //categorie wat alleen nodig is in deze klasse
    public class Categorie
    {
        public int ID { get; set; }
        public string SubCategorie_ID { get; set; }

        public string Categorienaam { get; set; }

        public Categorie(int id, string subCategorieId, string categorienaam)
        {
            ID = id;
            SubCategorie_ID = subCategorieId;

            Categorienaam = categorienaam;
        }
    }
}