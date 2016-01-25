using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;
using Oracle.ManagedDataAccess.Client;

namespace Wehkamp_Webapplicatie.Database
{
    public class SpecificatiesOracleContext : ISpecificatiesContext
    {
        //Verkrijg alle specificatie objecten op basis van 1 specificatie ID
        public void GetAllSpecificatiesByID(int Specificaties_ID, out Genre genre, out Kleur kleur,
            out Kraagvorm kraagvorm,
            out Maat maat, out Materiaal materiaal, out Merk merk, out Platform platform, out SoortArtikel soortArtikel)
        {
            Specificatie specificatie = GetAll().Find(item => item.ID == Specificaties_ID);

            Genre vgenre = null;
            Kleur vkleur = null;
            Kraagvorm vkraagvorm = null;
            Maat vmaat = null;
            Materiaal vmateriaal = null;
            Merk vmerk = null;
            Platform vplatform = null;
            SoortArtikel vsoortArtikel = null;

            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM Genre WHERE ID={0}", specificatie.Genre_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vgenre = new Genre(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["Genre"])
                                );

                        }
                    }
                }

            }


            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM kleur WHERE ID={0}", specificatie.Kleur_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vkleur = new Kleur(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["kleur"])
                                );

                        }
                    }
                }

            }

            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM kraagvorm WHERE ID={0}", specificatie.Kraagvorm_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vkraagvorm = new Kraagvorm(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["kraagvorm"])
                                );

                        }
                    }
                }

            }




            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM maat WHERE ID={0}", specificatie.Maat_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vmaat = new Maat(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["maat"])
                                );

                        }
                    }
                }

            }


            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM materiaal WHERE ID={0}", specificatie.Materiaal_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vmateriaal = new Materiaal(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["materiaal"])
                                );

                        }
                    }
                }

            }

            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM platform WHERE ID={0}", specificatie.Platform_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vplatform = new Platform(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["platform"])
                                );

                        }
                    }
                }

            }

            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM soortartikel WHERE ID={0}", specificatie.SoortArtikel_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vsoortArtikel = new SoortArtikel(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["ARTIKELBESCHRIJVING"])
                                );

                        }
                    }
                }

            }

            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM merk WHERE ID={0}", specificatie.Merk_ID);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            vmerk = new Merk(Convert.ToInt32(reader["ID"]),
                                Convert.ToString(reader["merknaam"]), Convert.ToString(reader["beschrijving"])
                                );

                        }
                    }
                }

            }
            genre = vgenre;
             kleur = vkleur;
             kraagvorm = vkraagvorm;
             maat = vmaat;
             materiaal = vmateriaal;
             merk = vmerk;
             platform = vplatform;
             soortArtikel = vsoortArtikel;


        }
    

        //verkrijg alle specificaties uit de DB
    public List<Specificatie> GetAll()
        {
            List<Specificatie> specificaties = new List<Specificatie>();
            using (OracleConnection conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string query = string.Format("Select * from Specificaties");
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                                        Specificatie specificatie = new Specificatie(Convert.ToInt32(reader["ID"]),
                                reader["merk_Id"].ToString(), reader["maat_Id"].ToString(), reader["kleur_Id"].ToString(), reader["materiaal_Id"].ToString(),
                                reader["kraagvorm_Id"].ToString(), reader["schachtwijdte"].ToString(), reader["soortArtikel_Id"].ToString(), reader["genre_Id"].ToString(),
                                reader["subGenre_Id"].ToString(), reader["ruimtelijkeInhoud"].ToString(),reader["platform_Id"].ToString());
                            specificaties.Add(specificatie);
                        }
                    }
                }
            }
            return specificaties;
        }
    }


    //klasse dat alleen in deze klasse word gebruikt
    public class Specificatie
    {
        public int ID { get; set; }
        public string Merk_ID { get; set; }
        public string Maat_ID { get; set; }
        public string Kleur_ID { get; set; }
    public string Materiaal_ID { get; set; }
    public string Kraagvorm_ID { get; set; }
    public string Schachtwijdte { get; set; }
    public string SoortArtikel_ID { get; set; }
    public string Genre_ID { get; set; }
    public string SubGenre_ID { get; set; }
    public string RuimtelijkeInhoud { get; set; }
    public string Platform_ID { get; set; }

        public Specificatie(int id, string merkId, string maatId, string kleurId, string materiaalId, string kraagvormId, string schachtwijdte, string soortArtikelId, string genreId, string subGenreId, string ruimtelijkeInhoud, string platformId)
        {


            ID = id;
            Merk_ID = merkId;
            Maat_ID = maatId;
            Kleur_ID = kleurId;
            Materiaal_ID = materiaalId;
            Kraagvorm_ID = kraagvormId;
            Schachtwijdte = schachtwijdte;
            SoortArtikel_ID = soortArtikelId;
            Genre_ID = genreId;
            SubGenre_ID = subGenreId;
            RuimtelijkeInhoud = ruimtelijkeInhoud;
            Platform_ID = platformId;

            if (Merk_ID.Length < 1)
            {
                Merk_ID = "0";
            }
            if (Maat_ID.Length < 1)
            {
                Maat_ID = "0";
            }
            if (Kleur_ID.Length < 1)
            {
                Kleur_ID = "0";
            }
            if (Materiaal_ID.Length < 1)
            {
                Materiaal_ID = "0";
            }
            if (Kraagvorm_ID.Length < 1)
            {
                Kraagvorm_ID = "0";
            }
            if (SoortArtikel_ID.Length < 1)
            {
                SoortArtikel_ID = "0";
            }
            if (SoortArtikel_ID.Length < 1)
            {
                Merk_ID = "0";
            }
            if (Genre_ID.Length < 1)
            {
                Genre_ID = "0";
            }
            if (Platform_ID.Length < 1)
            {
                Platform_ID = "0";
            }

        }


    }



}

