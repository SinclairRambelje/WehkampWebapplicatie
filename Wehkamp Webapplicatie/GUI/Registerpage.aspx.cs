using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Registerpage : System.Web.UI.Page
    {
        public AccountRepository AccountRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            AccountRepository = new AccountRepository();

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

        protected void BtRegisteer_Click(object sender, EventArgs e)
        {
            string Geslacht = null;
            if (RdGeslacht.SelectedIndex == 0)
            {
                Geslacht = "M";
            }
            else if(RdGeslacht.SelectedIndex == 1)
            {
                Geslacht = "V";
            }

            if (Geslacht.Length == 1 && TbWachtwoordherhaald.Text == Tbwachtwoord.Text && Tbwachtwoord.Text.Length >= 8)
            {
                AccountRepository.AddAccount(tbEmail.Text, TbVoornaam.Text, TbVoorletters.Text, TbAchternaam.Text, Geslacht, new DateTime(1990, 03, 03), TbPostcode.Text
                    ,TbWoonplaats.Text, Adres.Text, Convert.ToInt32(TbTelefoonnummer.Text), Convert.ToInt32(TbMobielnummer.Text),Tbwachtwoord.Text);
                LbRegisterCheck.Text = "Registratie is succesvol!";
            }
            else
            {
                LbRegisterCheck.Text = "Wachtwoord bezit niet juiste lengte, of komt niet overeen";
            }
          
        }
    }
}