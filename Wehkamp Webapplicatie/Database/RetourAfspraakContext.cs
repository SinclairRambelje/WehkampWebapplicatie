using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;
using Oracle.ManagedDataAccess.Client;

namespace Wehkamp_Webapplicatie.Database
{
    public class RetourAfspraakContext : IRetourAfspraakContext
    {
        //krijg alle retourafspraken
        public List<RetourAfspraak> GetAll()
        {
            List<RetourAfspraak> retourAfspraaken = new List<RetourAfspraak>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from RETOURAFSPRAAK");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Convert.ToInt32(reader["Factuurnummer"]),
                           //     reader["Klant_ID"].ToString(), reader["Betaalwijze_ID"].ToString(), null,
                             //   Convert.ToDateTime(reader["FactuurDatum"])

                            RetourAfspraak retourAfspraak = new RetourAfspraak(Convert.ToInt32(reader["ID"]), Convert.ToInt32(reader["Klant_ID"]), Convert.ToDateTime(reader["Datum"])
                                );
                            retourAfspraaken.Add(retourAfspraak);
                        }
                    }
                }
            }
            return retourAfspraaken;
        }

        //krijg alle retourafspraken op basis van account id
        public List<RetourAfspraak> GetbyID(int AccountID)
        {
            return GetAll().FindAll(item => item.Klant_ID == AccountID);
        }

        //krijg alle retouritems op basis van retourafspraak id
        public List<RetourItem> GetAllRetourAfspraakProductenByID(int RetourAfspraakID)
        {
            return GetAllRetourItems().FindAll(item => item.Retourafspraak_ID == RetourAfspraakID);
        }

        //krijg alle retouritems
        public List<RetourItem> GetAllRetourItems()
        {
            List<RetourItem> retourItems = new List<RetourItem>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from RetourItem");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Convert.ToInt32(reader["Factuurnummer"]),
                            //     reader["Klant_ID"].ToString(), reader["Betaalwijze_ID"].ToString(), null,
                            //   Convert.ToDateTime(reader["FactuurDatum"])

                            RetourItem retourItem = new RetourItem(Convert.ToInt32(reader["Product_ID"]), Convert.ToInt32(reader["FACTUURNUMMER_ID"]), Convert.ToInt32(reader["Retourafspraak_ID"]),
                                 Convert.ToDecimal(reader["TotaalBedrag"]), Convert.ToInt32(reader["Aantal"])
                                );
                            retourItems.Add(retourItem);
                        }
                    }
                }
            }
            return retourItems;
        }

        //voeg nieuwe retourafspraak toe aan de DB
        public void AddRetourAfspraak(RetourAfspraak retourAfspraak)
        {
            int id = Database.Instance.KrijgHoogsteID2("RETOURAFSPRAAK");
            string formateddatum = retourAfspraak.Datum.ToString("dd-MM-yyyy");
            string query = string.Format("Insert into RETOURAFSPRAAK (ID,Klant_ID,Datum" +
                                         ") values({0}, {1}, TO_DATE('{2}', 'dd/mm/yyyy hh24:mi:ss')) ",
                id, retourAfspraak.Klant_ID, formateddatum);
   
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

        //voeg nieuwew retouritem aan db
        public void AddRetourItem(RetourItem RetourItem)
        {
            
            
            string query = string.Format("Insert into RETOURITEM (Retourafspraak_ID,Product_ID,Factuurnummer_ID,Aantal,TotaalBedrag " +
                                         ") values({0}, {1}, {2}, {3}, {4}) ",
                RetourItem.Retourafspraak_ID, RetourItem.Product_ID, RetourItem.Factuurnummer_ID, RetourItem.Aantal, RetourItem.TotaalBedrag.ToString().Replace(",","."));

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