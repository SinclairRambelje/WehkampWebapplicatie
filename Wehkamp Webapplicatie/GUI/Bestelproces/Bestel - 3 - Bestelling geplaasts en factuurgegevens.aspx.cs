using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.GUI.Bestelproces
{
    public partial class Bestel___3___Bestelling_geplaasts_en_factuurgegevens : System.Web.UI.Page
    {
        public FactuurRepository FactuurRepository { get; set; }
        public ProductRepository ProductRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductRepository = new ProductRepository();
            FactuurRepository = new FactuurRepository();

            //algoritme om een factuur weer te geven die net geplaatst is
            Factuur factuur = Database.Database.Instance.JustPlacedFactuur;
            List<UNIEKPRODUCTGEKOCHT> uniekproductgekochten =
                FactuurRepository.GetAllFactuurProductenByID(factuur.Factuurnummer);

            LbFactuur.Items.Add("Factuurnummer: "+factuur.Factuurnummer.ToString());
            LbFactuur.Items.Add("Leverdatum: " + factuur.FactuurDatum.ToString());
            LbFactuur.Items.Add("BetaalwijzeID: " + factuur.Betaalwijze_ID.ToString());
            LbFactuur.Items.Add("-----------------------");

            decimal TotaalFactuurPrijs = 0;
            foreach (UNIEKPRODUCTGEKOCHT uniekproductgekocht in uniekproductgekochten)
            {
                Product product = ProductRepository.GetByID(uniekproductgekocht.Product_ID);
                LbFactuur.Items.Add("Naam: "+product.Productnaam + " Prijs:" + product.Prijs);
                TotaalFactuurPrijs += product.Prijs;
            }
            LbFactuur.Items.Add("Totaal:€" + TotaalFactuurPrijs.ToString());

        }

        protected void BtGaNaarHome_Click(object sender, EventArgs e)
        {
            Server.Transfer("/GUI/Homepagina.aspx");
        }
    }
}