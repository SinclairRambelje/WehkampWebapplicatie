using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Models;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI.Bestelproces
{
    public partial class Bestel___2___Betaalwijze_Selecteren : System.Web.UI.Page
    {
        public  ProductRepository ProductRepository { get; set; }
        public List<Betaalwijze> Betaalwijzes { get; set; }
        public FactuurRepository FactuurRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ProductRepository = new ProductRepository();
            FactuurRepository = new FactuurRepository();
            Betaalwijzes = new List<Betaalwijze>();

            //laad alle betaalwijzes
            foreach (Betaalwijze betaalwijze in ProductRepository.GetAllBetaalwijzes())
            {
                DDlistBetaalwzijzes.Items.Add(betaalwijze.Omschrijving);
                Betaalwijzes.Add(betaalwijze);
            }
        }

        protected void BtPlaatsBestelling_Click(object sender, EventArgs e)
        {
            //Voeg niewew factuur toe aan de DB
            Factuur factuur = new Factuur(0, Convert.ToString(Database.Database.Instance.LoggedAccount.Klantnummer), Betaalwijzes[DDlistBetaalwzijzes.SelectedIndex].ID.ToString(), null, Database.Database.Instance.VerzendDatum);
            FactuurRepository.AddFactuur(factuur);
            Database.Database.Instance.JustPlacedFactuur = factuur;
            foreach (Product product in Database.Database.Instance.Winkelmand.Producten)
            {
                UNIEKPRODUCTGEKOCHT productgekocht = new UNIEKPRODUCTGEKOCHT(0, product.ID, Database.Database.Instance.FactuurNummerJustPlaced, 1, product.Prijs);
                FactuurRepository.AddUniekProductGekocht(productgekocht);
            }

            //voorbereiding om net geplaatse factuur weer te geven
            Database.Database.Instance.JustPlacedFactuur.Factuurnummer =
                Database.Database.Instance.FactuurNummerJustPlaced;
                Server.Transfer("/GUI/Bestelproces/Bestel - 3 - Bestelling geplaasts en factuurgegevens.aspx");
        }
    }
}