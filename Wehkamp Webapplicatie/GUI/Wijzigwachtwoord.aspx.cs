using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Wijzigwachtwoord : System.Web.UI.Page
    {
        public AccountRepository AccountRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            AccountRepository = new AccountRepository();

            //voorkomt dat textboxes op null komen bij event click
            if (!IsPostBack)
            {
                Tbwachtwoord.Text = null;
                TbWachtwoordherhaald.Text = null;
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

        protected void BtWijzigWachtwoord_Click(object sender, EventArgs e)
        {
            //algortime om wachtwoord te wijzigen
            if (Tbwachtwoord.Text == TbWachtwoordherhaald.Text)
            {
                if (AccountRepository.EditPassword(Tbwachtwoord.Text))
                {
                    Server.Transfer("/GUI/Mijn gegevens.aspx");
                }
                else
                {
                    LbSuccesCheck.Text = "Invulwaardes niet voldaan aan voorwaardes";
                }
               
               
            }
            else
            {
                LbSuccesCheck.Text = "Ingevoerde wachtwoorden komen niet overeen";
            }
        }
    }
}