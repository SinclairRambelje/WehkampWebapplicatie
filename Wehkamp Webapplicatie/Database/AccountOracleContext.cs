using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Database
{
    public interface AccountOracleContext
    {

        Account GetByEmailPassword(string Email, string Password);

        void AddAccount(string Email, string Voornaam, string voorletters, string achternaam, string geslacht, DateTime Geboortedatum, string Postcode, string woonplaats, string adres, 
            int telefoonnumer, int Mobielnummer, string wachtwoord);

        bool EditAccount(Account account);

        bool EditPassword(String password);

        string GetNameByID(int klantnummer);

    }
}