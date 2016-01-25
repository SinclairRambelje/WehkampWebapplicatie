using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;
using Oracle.ManagedDataAccess.Client;

namespace Wehkamp_Webapplicatie.Database
{
    public class FactuurOracleContext : IFactuurContext
    {
        public List<Factuur> GetAll()
        {
            List<Factuur> facturen = new List<Factuur>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from FACTUUR");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            

                            Factuur product = new Factuur(Convert.ToInt32(reader["Factuurnummer"]),
                                reader["Klant_ID"].ToString(), reader["Betaalwijze_ID"].ToString(), null,
                                Convert.ToDateTime(reader["FactuurDatum"])
                                );
                            facturen.Add(product);
                        }
                    }
                }
            }
            return facturen;
        }

        public List<Factuur> GetbyID(int AccountID)
        {
            return GetAll().FindAll(item => Convert.ToInt32(item.Klant_ID) == AccountID);
        }

        public List<UNIEKPRODUCTGEKOCHT> GetAllFactuurProductenByID(int Factuurnummer)
        {
            return GetAllUniekProducten().FindAll(item => item.Factuurnummer_ID == Factuurnummer);
        }

        public List<UNIEKPRODUCTGEKOCHT> GetAllUniekProducten()
        {
            List<UNIEKPRODUCTGEKOCHT> uniekproductgekochten = new List<UNIEKPRODUCTGEKOCHT>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from UNIEKPRODUCTGEKOCHT");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           

                            UNIEKPRODUCTGEKOCHT product = new UNIEKPRODUCTGEKOCHT(Convert.ToInt32(reader["ID"]),
                                Convert.ToInt32(reader["Product_ID"]), Convert.ToInt32(reader["Factuurnummer_ID"]), 1,
                                Convert.ToDecimal(reader["TotaalBedrag"])
                                );
                            uniekproductgekochten.Add(product);
                        }
                    }
                }
            }
            return uniekproductgekochten;
        }

        public void AddFactuur(Factuur factuur)
        {
            int id = Database.Instance.KrijgHoogsteID("Factuur");
            string formateddatum = factuur.FactuurDatum.ToString("dd-MM-yyyy");
            string query = string.Format("Insert into FACTUUR (Factuurnummer,Klant_ID,FactuurDatum,Betaalwijze_ID" +
                                         ") values({0}, {1}, TO_DATE('{2}', 'dd/mm/yyyy hh24:mi:ss'), {3}) ",
                                         id, factuur.Klant_ID, formateddatum,
                                         factuur.Betaalwijze_ID);



            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                Console.WriteLine(query);
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddUniekProductGekocht(UNIEKPRODUCTGEKOCHT Productgekocht)
        {
            //(ID,Product_ID,Factuurnummer_ID,Aantal,TotaalBedrag
            int id = Database.Instance.KrijgHoogsteID2("UNIEKPRODUCTGEKOCHT");
            string bedrag = Productgekocht.TotaalBedrag.ToString().Replace(",", ".");
            
            string query = string.Format("Insert into UNIEKPRODUCTGEKOCHT (ID,Product_ID,Factuurnummer_ID,Aantal,TotaalBedrag" +
                                         ") values({0},{1},{2},{3},{4}) ",
                                         id, Productgekocht.Product_ID, Productgekocht.Factuurnummer_ID, 1,
                                         bedrag);



            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                Console.WriteLine(query);
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}