using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Wehkamp_Webapplicatie.Database
{
    public class IAccountContext : AccountOracleContext
    {
        public Account account { get; set; }

        // krijg account op basis van email en password(inloggen)
        public Account GetByEmailPassword(string Email, string Password)
        {
            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT * FROM account WHERE Email='{0}' and Wachtwoord='{1}'", Email,
                    Password);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            account = new Account(Convert.ToInt32(reader["Klantnummer"]),
                                Convert.ToString(reader["Voorletters"]), Convert.ToString(reader["Achternaam"]),
                                Convert.ToString(reader["voornaam"]), Convert.ToString(reader["geslacht"]),
                                Convert.ToDateTime(reader["Geboortedatum"]),
                                Convert.ToString(reader["adres"]), Convert.ToString(reader["postcode"]),
                                Convert.ToString(reader["woonplaats"]),
                                Convert.ToInt32(reader["telefoonThuis"]), Convert.ToInt32(reader["telefoonMobiel"]),
                                Convert.ToInt32(reader["telefoonWerk"]),
                                Convert.ToString(reader["eMail"]), Convert.ToString(reader["wachtwoord"]),
                                Convert.ToString(reader["bezorgvoorkeur"]),
                                Convert.ToString(reader["emailvoorkeur"]), Convert.ToString(reader["cookievoorkeur"]),
                                Convert.ToString(reader["productvoorkeur"]), Convert.ToString(reader["betaalvoorkeur"]));

                            return account;
                        }
                    }
                }
            }
            return account;
        }

        //voeg nieuw account aan DB(registeren)
        public void AddAccount(string Email, string Voornaam, string voorletters, string achternaam, string geslacht,
            DateTime Geboortedatum, string Postcode, string woonplaats, string adres,
            int telefoonnumer, int Mobielnummer, string wachtwoord)
        {
            int id = Database.Instance.KrijgHoogsteID3("Account");
            string formateddatum = Geboortedatum.ToString("dd-MM-yyyy");
            string query = string.Format("Insert into ACCOUNT (Klantnummer,Voorletters,Achternaam,Voornaam,Geslacht," +
                                         "Geboortedatum,Adres,Postcode,Woonplaats,TelefoonThuis,TelefoonMobiel,TelefoonWerk," +
                                         "Email,Wachtwoord,Bezorgvoorkeur,Emailvoorkeur,Cookievoorkeur,Productvoorkeur,Betaalvoorkeur" +
                                         ") values ({0},'{1}','{2}','{3}','{4}',to_date('{5}','dd/mm/yyyy'), " +
                                         "'{6}', '{7}', '{8}', {9}, {10}, {11}," +
                                         " '{12}', '{13}', '{14}',  '{15}', '{16}', '{17}', '{18}') ",
                id, voorletters, achternaam, Voornaam, geslacht, formateddatum, adres, Postcode, woonplaats,
                telefoonnumer, Mobielnummer, 0
                , Email, wachtwoord, "Toegestaan", "Niet toegestaan", "Nee", "Nee", "Belansrekening sluiten")
                ;


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

        //wijzigt accountgegevens op basis van accound id
        public bool EditAccount(Account account)
        {
            try
            {
                using (OracleConnection conn = Database.Instance.GetConnection())
                {
                    string formateddatum = account.Geboortedatum.ToString("dd-MM-yyyy");
                    string query = string.Format("UPDATE ACCOUNT SET Voorletters = '{0}'" +
                                                 ", Achternaam = '{1}'" +
                                                 ", geslacht = '{2}'" +
                                                 ", Voornaam = '{3}'" +
                                                 ",Geboortedatum = to_date('{4}', 'dd/mm/yyyy')" +
                                                 ", Postcode = '{5}'" +
                                                 ", Adres = '{6}'" +
                                                 ", Woonplaats = '{7}'" +
                                                 ", TelefoonThuis = {8}" +
                                                 ", TelefoonMobiel = {9}" +
                                                 ", TELEFOONWERK = {10}" +
                                                 ", BEZORGVOORKEUR = '{11}'," +
                                                 " EMAILVOORKEUR = '{12}'" +
                                                 ", COOKIEVOORKEUR = '{13}'" +
                                                 ", PRODUCTVOORKEUR = '{14}'" +
                                                 ", BETAALVOORKEUR = '{15}'" +
                                                 "where klantnummer = {16}",
                        account.Voorletters, account.Achternaam, account.Geslacht, account.Voornaam, formateddatum,
                        account.Postcode, account.Adres, account.Woonplaats, account.TelefoonThuis,
                        account.TelefoonMobiel, account.TelefoonWerk, account.Bezorgvoorkeur, account.Emailvoorkeur,
                        account.Cookievoorkeur, account.Productvoorkeur, account.Betaalvoorkeur, account.Klantnummer
                        )
                        ;

                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }


            return true;
        }

        //wijzig wachtwoord op basis van account id
        public bool EditPassword(string password)
        {
            try
            {
                using (OracleConnection conn = Database.Instance.GetConnection())
                {
                    string query = string.Format("UPDATE ACCOUNT SET wachtwoord = {0}" +
                                                 "where klantnummer = {1}",
                        password, Database.Instance.LoggedAccount.Klantnummer);


                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //krijg naam op basis van account id(om voornaam te showen bij reviews)
        public string GetNameByID(int klantnummer)
        {
            string naam = "";
            using (OracleConnection con = Database.Instance.GetConnection())
            {
                con.Open();
                string query = String.Format("SELECT voornaam FROM account WHERE klantnummer={0}", klantnummer);
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            naam =
                                Convert.ToString(reader["voornaam"]);

                            return naam;
                        }
                    }
                }
            }
            return naam;
        }
    }
}