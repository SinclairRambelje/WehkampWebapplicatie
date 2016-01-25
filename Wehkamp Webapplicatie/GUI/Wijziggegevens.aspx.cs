using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Wijziggegevens : System.Web.UI.Page
    {
        public Account Account { get; set; }
        public AccountRepository AccountRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Account = Database.Database.Instance.LoggedAccount;
            AccountRepository = new AccountRepository();

            //voorkomt dat textboxes op null komen bij event click
            if (!IsPostBack)
            {
                TbVoornaam.Text = Account.Voornaam;
                TbVoorletters.Text = Account.Voorletters;
                TbAchternaam.Text = Account.Achternaam;
                if (Account.Geslacht == "m")
                {
                    RdGeslacht.Items[0].Selected = true;
                }
                else
                {
                    RdGeslacht.Items[0].Selected = false;
                }
                TbGeboortedatum.Text = Account.Geboortedatum.ToString("dd-MM-yyyy");
                TbPostcode.Text = Account.Postcode.ToString();
                TbAdres.Text = Account.Adres;
                TbWoonplaats.Text = Account.Woonplaats;
                TbTelefoonnummer.Text = Account.TelefoonThuis.ToString();
                TbMobielnummer.Text = Account.TelefoonMobiel.ToString();
            }

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
            //algoritme om gegevens te wijzigen
            string geslacht;
            if (RdGeslacht.SelectedIndex == 0)
            {
                geslacht = "M";
            }
            else
            {
                geslacht = "V";
            }
            Account account = new Account(Database.Database.Instance.LoggedAccount.Klantnummer, TbVoorletters.Text, TbAchternaam.Text, TbVoornaam.Text, geslacht, new DateTime(1990, 03, 03), TbAdres.Text
                ,TbPostcode.Text, TbWoonplaats.Text, Convert.ToInt32(TbTelefoonnummer.Text), Convert.ToInt32(TbMobielnummer.Text), Convert.ToInt32(TbTelefoonwerk.Text), "nvt", "nvt", RbBezorgvoorkeur.SelectedItem.Text, RbEmailvoorkeur.SelectedItem.Text,
                RbCookievoorkeur.SelectedItem.Text, RbProductvoorkeur.SelectedItem.Text, RbBetaalvoorkeur.SelectedItem.Text);

            if (AccountRepository.EditAccount(account))
            {
                Database.Database.Instance.LoggedAccount = account;
                Server.Transfer("/GUI/Mijn gegevens.aspx");
            }
            else
            {
                LbGeluktCheck.Text = "Registeren mislukt, let op invul voorwaardes!";
            }

            
        }
    }
}