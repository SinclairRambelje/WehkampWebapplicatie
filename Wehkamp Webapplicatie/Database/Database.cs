using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Wehkamp_Webapplicatie.Logic;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Database
{
    public class Database
    {
        private static Database instance;

        private static readonly string connectionString =
            "User Id=dbi324175;Password=wgSZJnGDZe;Data Source=fhictora01.fhict.local:1521/fhictora;";

        public Account LoggedAccount { get; set; }
        public Account tempaccount { get; set; }
        public Product ProductBekijken { get; set; }
        public Winkelmand Winkelmand { get; set; }
        public DateTime VerzendDatum { get; set; }
        public Factuur JustPlacedFactuur { get; set; }
        public int FactuurNummerJustPlaced { get; set; }
        public string RecensteZoekOpdracht { get; set; }
        public List<Retourneeritem> RetourneerLijst { get; set; }
        public RetourAfspraak JustPlacedRetourAfspraak { get; set; }
        public int RetourAfspraakIDJustPlaced { get; set; }
        public string DynamicLink { get; set; }

        //Zorgt ervoor dat de winkelmand nooit null is
        public Database()
        {
            Winkelmand = new Winkelmand();
        }

        //singelton database
        public static Database Instance // singleton
        {
            get { return instance ?? (instance = new Database()); }
        }

        //DB connection
        public OracleConnection GetConnection()
        {
            return
                new OracleConnection(
                    connectionString);
        }

        //Krijgt hoogste factuurnummer(primairy key) van tabel
        public int KrijgHoogsteID(string tabel)
        {
            int newID = 0;
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string query = string.Format("Select MAX(factuurnummer) as Hoogst from {0}", tabel);
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        newID = reader.GetInt32(0);
                    }
                }
                //slaat factuurnummer op om juiste geplaatste factuur te tonen
                FactuurNummerJustPlaced = newID + 1;
                return newID + 1;
            }
        }

        //Krijgt hoogste id(primairy key) van tabel
        public int KrijgHoogsteID2(string tabel)
        {
            int newID = 0;
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string query = string.Format("Select MAX(id) as Hoogst from {0}", tabel);
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        newID = reader.GetInt32(0);
                    }
                }
                //slaat id op om juiste geplaatste factuur te tonen
                RetourAfspraakIDJustPlaced = newID + 1;
                return newID + 1;
            }
        }

        //Krijgt hoogste klantnummer(primairy key) van tabel
        public int KrijgHoogsteID3(string tabel)
        {
            int newID = 0;
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string query = string.Format("Select MAX(klantnummer) as Hoogst from {0}", tabel);
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        newID = reader.GetInt32(0);
                    }
                }
                return newID + 1;
            }
        }
    }
}