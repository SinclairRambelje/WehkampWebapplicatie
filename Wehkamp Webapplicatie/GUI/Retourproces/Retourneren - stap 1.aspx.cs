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
    public partial class Retourneren : System.Web.UI.Page
    {
        public FactuurRepository FactuurRepository { get; set; }
        public ProductRepository ProductRepository { get; set; }
        public List<Factuur> Factuurs { get; set; }
        public List<UNIEKPRODUCTGEKOCHT> Uniekproductgekochts { get; set; }
        public RetourafspraakRepository RetourafspraakRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RetourafspraakRepository = new RetourafspraakRepository();
            Uniekproductgekochts = new List<UNIEKPRODUCTGEKOCHT>();
            ProductRepository = new ProductRepository();
            FactuurRepository = new FactuurRepository();
            Factuurs = FactuurRepository.GetbyID(Database.Database.Instance.LoggedAccount.Klantnummer);

            if (!IsPostBack)
            {
                foreach (Factuur factuur in Factuurs)
                {

                    LbFactures.Items.Add("Factuurnummer: " + factuur.Factuurnummer.ToString() + " Leverdatum: " +
                                         factuur.FactuurDatum.ToString() + " BetaalwijzeID: " +
                                         factuur.Betaalwijze_ID.ToString());
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Database.Database.Instance.JustPlacedFactuur =
                FactuurRepository.GetbyID(Database.Database.Instance.LoggedAccount.Klantnummer)[LbFactures.SelectedIndex];

            Uniekproductgekochts =
               FactuurRepository.GetAllFactuurProductenByID(FactuurRepository.GetbyID(Database.Database.Instance.LoggedAccount.Klantnummer)[LbFactures.SelectedIndex].Factuurnummer);
            if (Database.Database.Instance.RetourneerLijst == null)
            {
                Database.Database.Instance.RetourneerLijst = new List<Retourneeritem>();
                foreach (UNIEKPRODUCTGEKOCHT Uniekproductgekocht in Uniekproductgekochts)
                {
                    Product product = ProductRepository.GetByID(Uniekproductgekocht.Product_ID);
                    Retourneeritem retourneeritem = new Retourneeritem(product, Uniekproductgekocht.Factuurnummer_ID);
                    Database.Database.Instance.RetourneerLijst.Add(retourneeritem);
                }

            }
            else
                foreach (UNIEKPRODUCTGEKOCHT Uniekproductgekocht in Uniekproductgekochts)
                {
                    Product product = ProductRepository.GetByID(Uniekproductgekocht.Product_ID);

                    Retourneeritem retourneeritem = new Retourneeritem(product, Uniekproductgekocht.Factuurnummer_ID);
                    Database.Database.Instance.RetourneerLijst.Add(retourneeritem);
                }

            LbRetourneerlijst.Items.Clear();
            foreach (Retourneeritem retourneeritem in Database.Database.Instance.RetourneerLijst)
            {
                LbRetourneerlijst.Items.Add("factuurnummer" + retourneeritem.Factuurnummer_ID + " " + retourneeritem.Product.Productnaam + " " + retourneeritem.Product.Prijs);
            }
        }

        protected void BtVerwijderGeselecteerdeRetourneerItem_Click(object sender, EventArgs e)
        {
            
            Database.Database.Instance.RetourneerLijst.RemoveAt(LbRetourneerlijst.SelectedIndex);
            LbRetourneerlijst.Items.Clear();
            foreach (Retourneeritem retourneeritem in Database.Database.Instance.RetourneerLijst)
            {
                LbRetourneerlijst.Items.Add("factuurnummer" + retourneeritem.Factuurnummer_ID + " " + retourneeritem.Product.Productnaam + " " + retourneeritem.Product.Prijs);
            }
        }

        protected void BtVerwijderAlleItems_Click(object sender, EventArgs e)
        {
            LbRetourneerlijst.Items.Clear();
            Database.Database.Instance.RetourneerLijst.Clear();
        }

        protected void BtNaarStap2_Click(object sender, EventArgs e)
        {
            //slaat temporary nieuw retourafspraak op, en verzend het naar oracle DB
           RetourAfspraak retourAfspraak = new RetourAfspraak(0, Database.Database.Instance.LoggedAccount.Klantnummer, DateTime.Now);
            RetourafspraakRepository.AddRetourAfspraak(retourAfspraak);
            retourAfspraak.ID = Database.Database.Instance.RetourAfspraakIDJustPlaced;
            Database.Database.Instance.JustPlacedRetourAfspraak = retourAfspraak;
            foreach (Retourneeritem retourneeritem in Database.Database.Instance.RetourneerLijst)
            {
                RetourItem retourItem = new RetourItem(retourneeritem.Product.ID, retourneeritem.Factuurnummer_ID, retourAfspraak.ID, retourneeritem.Product.Prijs, 1);
                RetourafspraakRepository.AddRetourItem(retourItem);
            }



            Server.Transfer("/GUI/Retourproces/Retourneren - stap 2.aspx");
        }
    }
}