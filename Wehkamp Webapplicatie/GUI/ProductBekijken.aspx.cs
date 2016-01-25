using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Models;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class ProductBekijken : System.Web.UI.Page
    {
        public BeoordelingRepository BeoordelingRepository { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Database.Database.Instance.ProductBekijken.Productnaam;

            //Maak specificaties aan, zet ze alvast op null indien ze niet worden ingevuld
            Genre vgenre = null;
            Kleur vkleur = null;
            Kraagvorm vkraagvorm = null;
            Maat vmaat = null;
            Materiaal vmateriaal = null;
            Merk vmerk = null;
            Platform vplatform = null;
            SoortArtikel vsoortArtikel = null;

            //laad bovenstaande productspecificatie objecten
            SpecificatiesRepository specificatiesRepository = new SpecificatiesRepository();
             specificatiesRepository.GetAllSpecificatiesByID(Database.Database.Instance.ProductBekijken.Specificaties_ID, out vgenre, out vkleur, out vkraagvorm, out vmaat
              , out vmateriaal, out vmerk, out vplatform, out vsoortArtikel);
            BeoordelingRepository = new BeoordelingRepository();

            //laad beoordelingen van product, en laat ze zien met listview
            List<Beoordeling> beoordelingen =
                BeoordelingRepository.GetByProductID(Database.Database.Instance.ProductBekijken.ID);
            ListView1.DataSource = beoordelingen;
            ListView1.DataBind();

            //berekent gem score van product
            decimal gemBeoordelingsCijfer = 0;
            foreach (Beoordeling beoordeling in beoordelingen)
            {
                gemBeoordelingsCijfer += beoordeling.Beoordelingcijfer;
            }
            if (gemBeoordelingsCijfer == 0)
            {
                Lbgemiddelde.Text = Convert.ToString(gemBeoordelingsCijfer);
            }
            else
            {
                Lbgemiddelde.Text = Convert.ToString(gemBeoordelingsCijfer/beoordelingen.Count());
            }
            

            //voorkomt dat specifiatie table opnieuw word gelade
            if (!IsPostBack)
            {
                if (vgenre != null)
                {
                    LbSpecificaties.Items.Add(vgenre.GenreNaam);
                }
                if (vkleur != null)
                {
                    LbSpecificaties.Items.Add(vkleur.KleurNaam);
                }
                if (vkraagvorm != null)
                {
                    LbSpecificaties.Items.Add(vkraagvorm.KraagvormMaat);
                }
                if (vmaat != null)
                {
                    LbSpecificaties.Items.Add(vmaat.MerkGroote);
                }
                if (vmateriaal != null)
                {
                    LbSpecificaties.Items.Add(vmateriaal.Materiaalnaam);
                }
                if (vmerk != null)
                {
                    LbSpecificaties.Items.Add(vmerk.MerkNaam);
                }
                if (vplatform != null)
                {
                    LbSpecificaties.Items.Add(vplatform.Platformnaam);
                }
                if (vsoortArtikel != null)
                {
                    LbSpecificaties.Items.Add(vsoortArtikel.Beschrijving);
                }

                
            }




            //mastercontrol
            Label LbWelkom = this.Master.FindControl("LbWelkom") as Label;
            Label LbWinkelmandItems = this.Master.FindControl("LbWinkelmandItems") as Label;
            Label LbWinkelmandTotaal = this.Master.FindControl("LbWinkelmandTotaal") as Label;
            
            if (Database.Database.Instance.LoggedAccount == null)
            {
                LbWelkom.Text = "Welkom bezoeker!";
            }
            else
            {
                LbWelkom.Text = "Welkom terug " + Database.Database.Instance.LoggedAccount.Voornaam + "!";
            }

            LbWinkelmandItems.Text = Convert.ToString(Database.Database.Instance.Winkelmand.Producten.Count());
            LbWinkelmandTotaal.Text = Convert.ToString(Database.Database.Instance.Winkelmand.TotaalBedragAanContent());
        }

        protected void LbSpecificaties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void StopInWinkelMand(object sender, EventArgs e)
        {
            //algoritme om product in winkelmand te stoppen
            Database.Database.Instance.Winkelmand.Producten.Add(Database.Database.Instance.ProductBekijken);

            LbWMNotificatie.Text = "Product is in de winkelmand gestopt!";
            LbWMNotificatie.BackColor = Color.Green;

            //refresh mijn winkelmand weergave mastercontrol
            Label LbWelkom = this.Master.FindControl("LbWelkom") as Label;
            Label LbWinkelmandItems = this.Master.FindControl("LbWinkelmandItems") as Label;
            Label LbWinkelmandTotaal = this.Master.FindControl("LbWinkelmandTotaal") as Label;
            
            if (Database.Database.Instance.LoggedAccount == null)
            {
                LbWelkom.Text = "Welkom bezoeker!";
            }
            else
            {
                LbWelkom.Text = "Welkom terug " + Database.Database.Instance.LoggedAccount.Voornaam + "!";
            }
            LbWinkelmandItems.Text = Convert.ToString(Database.Database.Instance.Winkelmand.Producten.Count());
            LbWinkelmandTotaal.Text = Convert.ToString(Database.Database.Instance.Winkelmand.TotaalBedragAanContent());
        }

        protected void BtMaakBeoordeling_Click(object sender, EventArgs e)
        {
            //brengt gebruiker naar beoordeling pagina (indien ingelogd)
            if (Database.Database.Instance.LoggedAccount != null)
            {
                Server.Transfer("AddBeoordeling.aspx");
            }
            else
            {
                LbCheckLogged.Text = "Je moet eerst inloggen voordat je een beoordeling kan plaatsen";
            }
        }
    }
}