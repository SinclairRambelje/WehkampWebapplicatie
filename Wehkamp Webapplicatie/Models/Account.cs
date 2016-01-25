using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie
{
    public class Account
    {
        public int Klantnummer { get; set; }
        public string Voorletters { get; set; }
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }
        public string Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public int TelefoonThuis { get; set; }
        public int TelefoonMobiel { get; set; }
        public int TelefoonWerk { get; set; }
        public string EMail { get; set; }
        public string Wachtwoord { get; set; }
        public string Bezorgvoorkeur { get; set; }
        public string Emailvoorkeur { get; set; }
        public string Cookievoorkeur { get; set; }
        public string Productvoorkeur { get; set; }
        public string Betaalvoorkeur { get; set; }
        

        public Account(int klantnummer, string voorletters, string achternaam, string voornaam, string geslacht, DateTime geboortedatum, string adres, string postcode, string woonplaats, int telefoonThuis, int telefoonMobiel, int telefoonWerk, string eMail, string wachtwoord, string bezorgvoorkeur, string emailvoorkeur, string cookievoorkeur, string productvoorkeur, string betaalvoorkeur)
        {
            Klantnummer = klantnummer;
            Voorletters = voorletters;
            Achternaam = achternaam;
            Voornaam = voornaam;
            Geslacht = geslacht;
            Geboortedatum = geboortedatum;
            Adres = adres;
            Postcode = postcode;
            Woonplaats = woonplaats;
            TelefoonThuis = telefoonThuis;
            TelefoonMobiel = telefoonMobiel;
            TelefoonWerk = telefoonWerk;
            EMail = eMail;
            Wachtwoord = wachtwoord;
            Bezorgvoorkeur = bezorgvoorkeur;
            Emailvoorkeur = emailvoorkeur;
            Cookievoorkeur = cookievoorkeur;
            Productvoorkeur = productvoorkeur;
            Betaalvoorkeur = betaalvoorkeur;
           
        }

      
    }
}