using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Database;

namespace Wehkamp_Webapplicatie.Logic
{
    
    public class AccountRepository
    {
        

        public IAccountContext iAccountOracleContext { get; set; }

        public AccountRepository()
        {
            iAccountOracleContext = new IAccountContext();
        }

        public Account GetAccountByEmailPassword(string Email, string Wachtwoord)
        {
            return iAccountOracleContext.GetByEmailPassword(Email, Wachtwoord);
        }

        public void AddAccount(string Email, string Voornaam, string voorletters, string achternaam, string geslacht,
            DateTime Geboortedatum, string Postcode, string woonplaats, string adres,
            int telefoonnumer, int Mobielnummer, string wachtwoord)
        {
            iAccountOracleContext.AddAccount( Email,  Voornaam,  voorletters,  achternaam,  geslacht,
             Geboortedatum,  Postcode,  woonplaats,  adres,
             telefoonnumer,  Mobielnummer,  wachtwoord);
        }

        public bool EditAccount(Account account)
        {
          return  iAccountOracleContext.EditAccount(account);
        }

        public bool EditPassword(string password)
        {
            return iAccountOracleContext.EditPassword(password);
        }

        public string GetNameByID(int klantnummer)
        {
            return iAccountOracleContext.GetNameByID(klantnummer);
        }
    }
}