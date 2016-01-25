using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;
using Wehkamp_Webapplicatie.Models;


namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Mijn_Retourneerafspraken : System.Web.UI.Page
    {
        public FactuurRepository FactuurRepository { get; set; }
        public ProductRepository ProductRepository { get; set; }
        public List<RetourAfspraak> RetourAfspraaken { get; set; }
        public RetourafspraakRepository RetourafspraakRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RetourafspraakRepository = new RetourafspraakRepository();
            ProductRepository = new ProductRepository();
            FactuurRepository = new FactuurRepository();
            RetourAfspraaken = RetourafspraakRepository.GetbyID(Database.Database.Instance.LoggedAccount.Klantnummer);

            //algortime om alle retourafspraken te tonen
            int AantalRetourafspraken = 1;
            foreach (RetourAfspraak retourAfspraak in RetourAfspraaken)
            {
                LbRetourafspraken.Items.Add("-----------Retourafspraak:" + AantalRetourafspraken.ToString());
                LbRetourafspraken.Items.Add("RetourAfspraakID: " + retourAfspraak.ID.ToString());
                LbRetourafspraken.Items.Add("Datum: " + retourAfspraak.Datum.ToString());
                LbRetourafspraken.Items.Add("-----------------------");
               
                foreach (
                    RetourItem retourItem in
                        RetourafspraakRepository.GetAllRetourAfspraakProductenByID(retourAfspraak.ID))
                {
                    Product product = ProductRepository.GetByID(retourItem.Product_ID);
                    LbRetourafspraken.Items.Add("Naam: " + product.Productnaam + " Prijs:" + product.Prijs);
                    
                }
                
                LbRetourafspraken.Items.Add("");
                LbRetourafspraken.Items.Add("");
                AantalRetourafspraken += 1;
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
    }
}