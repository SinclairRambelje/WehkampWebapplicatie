using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Mijn_gegevens : System.Web.UI.Page
    {
        public Account Account { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Account = Database.Database.Instance.LoggedAccount;

            //algoritme om gegevens te tonen
            string title;
            if (Account.Geslacht == "M")
            {
                title = "Dhr";
            }
            else
            {
                title = "Mw";
            }
            LbGegevens.Items.Add("Persoongegevens:");
            LbGegevens.Items.Add(title + " " +  Account.Voorletters + " "  + Account.Voornaam);
            LbGegevens.Items.Add(Account.Achternaam);
            LbGegevens.Items.Add("Geboortedatum:" + Account.Geboortedatum.ToString("dd-MM-yyyy"));
            LbGegevens.Items.Add("");
            LbGegevens.Items.Add("Adresgegevens:");
            LbGegevens.Items.Add(Account.Woonplaats);
            LbGegevens.Items.Add(Account.Adres);
            LbGegevens.Items.Add(Account.Postcode);
            LbGegevens.Items.Add("");
            LbGegevens.Items.Add("Email en telefoonnumers:");
            LbGegevens.Items.Add("Email:" + Account.EMail);
            LbGegevens.Items.Add("Telefoonthuis:" + Account.TelefoonThuis.ToString());
            LbGegevens.Items.Add("Telefoonmobiel:" + Account.TelefoonMobiel.ToString());
            LbGegevens.Items.Add("Telefoonwerk:" + Account.TelefoonWerk.ToString());

            //mastercontrol
            Label LbWelkom = this.Master.FindControl("LbWelkom") as Label;
            Label LbWinkelmandItems = this.Master.FindControl("LbWinkelmandItems") as Label;
            Label LbWinkelmandTotaal = this.Master.FindControl("LbWinkelmandTotaal") as Label;
            Menu MenuLoggedIn = this.Master.FindControl("MenuLoggedIn") as Menu;

            if (Database.Database.Instance.LoggedAccount == null)
            {
                LbWelkom.Text = "Welkom bezoeker!";

            }
            else
            {
                LbWelkom.Text = "Welkom terug " + Database.Database.Instance.LoggedAccount.Voornaam + "!";
                MenuLoggedIn.Visible = true;
            }

            LbWinkelmandItems.Text = Convert.ToString(Database.Database.Instance.Winkelmand.Producten.Count());
            LbWinkelmandTotaal.Text = Convert.ToString(Database.Database.Instance.Winkelmand.TotaalBedragAanContent());
        }

        protected void BtWijzigGegevens_Click(object sender, EventArgs e)
        {
            //zend naar wijziggegevens pagina
            Server.Transfer("/GUI/Wijziggegevens.aspx");
        }

        protected void BtWijzigWachtwoord_Click(object sender, EventArgs e)
        {
            //zend naar wijziggegevens pagina
            Server.Transfer("/GUI/Wijzigwachtwoord.aspx");
        }
    }
}