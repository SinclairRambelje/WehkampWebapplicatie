using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;
using Oracle.ManagedDataAccess.Client;

namespace Wehkamp_Webapplicatie.Database
{
    public class BeoordelingOracleContext : IBeoordelingContext
    {
        //Returned all Beoordelingen uit de database
        public List<Beoordeling> GetAll()
        {
            List<Beoordeling> beoordelingen = new List<Beoordeling>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from beoordeling");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Beoordeling beoordeling = new Beoordeling(Convert.ToInt32(reader["ID"]),
                                Convert.ToInt32(reader["Product_ID"]), Convert.ToInt32(reader["Klantnummer"]),
                                Convert.ToInt32(reader["Beoordeling"]), Convert.ToDateTime(reader["Datum"])
                                , reader["Title"].ToString(), reader["Bericht"].ToString());
                            beoordelingen.Add(beoordeling);
                        }
                    }
                }
            }
            return beoordelingen;
        }

        //Returned all Beoordelingen dat een ID heeft dat gelijk is aan de ingevoerde ID
        public List<Beoordeling> GetByProductID(int product_ID)
        {
            return GetAll().FindAll(item => item.Product_ID == product_ID);
        }

        //Voegt Beoordeling toe aan de databas
        public bool AddBeoordeling(Beoordeling beoordeling)
        {
            int id = Database.Instance.KrijgHoogsteID2("Beoordeling");

            string formateddatum = beoordeling.Datum.ToString("dd-MM-yyyy");
            string query =
                string.Format(
                    "Insert into Beoordeling (ID,Product_ID,Klantnummer,Beoordeling,Datum,Title,Bericht) values ({0},{1},{5},{2},to_date('{6}','dd/mm/yyyy'),'{3}','{4}')",
                    id, beoordeling.Product_ID, beoordeling.Beoordelingcijfer, beoordeling.Title, beoordeling.Bericht,
                    beoordeling.Klantnummer, formateddatum
                    );


            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                Console.WriteLine(query);
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}