using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Winkelmand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //laad listview met de producten in de winkelmand
            ListView1.DataSource = Database.Database.Instance.Winkelmand.Producten;
            ListView1.DataBind();

            LbTotaal.Text = Convert.ToString(Database.Database.Instance.Winkelmand.TotaalBedragAanContent());

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

        public void VerwijderProduct(object sender, EventArgs e)
        {
            //verwijderd de winkelmandproduct en herlaad pagina
            Button myButton = (Button)sender;
            Database.Database.Instance.Winkelmand.Producten.Remove(Database.Database.Instance.Winkelmand.Producten.Find(item => item.ID == Convert.ToInt32(myButton.CommandArgument.ToString())));

            Response.Redirect(Request.RawUrl);
        }

        public void BekijkProduct(object sender, EventArgs e)
        {
            //laat de productpagina zien van product
            Button myButton = (Button)sender;
            Database.Database.Instance.ProductBekijken =
                Database.Database.Instance.Winkelmand.Producten.Find(
                    item => item.ID == Convert.ToInt32(myButton.CommandArgument.ToString()));
               

            Server.Transfer("ProductBekijken.aspx");
        }

        protected void BtCheckOut_Click(object sender, EventArgs e)
        {
            //brengt gebruiker naar bestelproces, indien ingelogd
            if (Database.Database.Instance.LoggedAccount == null)
            {
                LbCheckOutCheck.Text = "U moet zich inloggen of registeren";
            }
            else
            {
                Server.Transfer("/GUI/Bestelproces/Bestel - 1 - Verzenadres.aspx");
            }
        }

        protected void BtVerwijderAlles_Click(object sender, EventArgs e)
        {
            //verwijderd alle producten uit de winkelmand
            Database.Database.Instance.Winkelmand.Producten.Clear();
            Response.Redirect(Request.RawUrl);
        }
    }
}