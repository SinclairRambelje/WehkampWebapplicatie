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
    public partial class Mijn_Bestellingen : System.Web.UI.Page
    {
        public FactuurRepository FactuurRepository { get; set; }
        public ProductRepository ProductRepository { get; set; }
        public List<Factuur> Factuurs { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductRepository = new ProductRepository();
            FactuurRepository = new FactuurRepository();
            Factuurs = FactuurRepository.GetbyID(Database.Database.Instance.LoggedAccount.Klantnummer);

            //algoritime om alle bestellingen weer te geven
            int AantalFactures = 1;
            foreach (Factuur factuur in Factuurs)
            {
                LbFactures.Items.Add("-----------FACTUUR:" + AantalFactures.ToString());
                LbFactures.Items.Add("Factuurnummer: " + factuur.Factuurnummer.ToString());
                LbFactures.Items.Add("Leverdatum: " + factuur.FactuurDatum.ToString());
                LbFactures.Items.Add("BetaalwijzeID: " + factuur.Betaalwijze_ID.ToString());
                LbFactures.Items.Add("-----------------------");
                decimal TotaalFactuurPrijs = 0;
                foreach (
                    UNIEKPRODUCTGEKOCHT uniekproductgekocht in
                        FactuurRepository.GetAllFactuurProductenByID(factuur.Factuurnummer))
                {
                    Product product = ProductRepository.GetByID(uniekproductgekocht.Product_ID);
                    LbFactures.Items.Add("Naam: " + product.Productnaam + " Prijs:" + product.Prijs);
                    TotaalFactuurPrijs += product.Prijs;
                }
                LbFactures.Items.Add("Totaal:€" + TotaalFactuurPrijs.ToString());
                LbFactures.Items.Add("");
                LbFactures.Items.Add("");
                AantalFactures += 1;
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