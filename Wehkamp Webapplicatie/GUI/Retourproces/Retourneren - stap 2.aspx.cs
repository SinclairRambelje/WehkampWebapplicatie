using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.GUI.Retourproces
{
    public partial class Retourneren___stap_2 : System.Web.UI.Page
    {
        public FactuurRepository FactuurRepository { get; set; }
        public ProductRepository ProductRepository { get; set; }
        public List<Factuur> Factuurs { get; set; }
        public List<UNIEKPRODUCTGEKOCHT> Uniekproductgekochts { get; set; }
        public RetourafspraakRepository RetourafspraakRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RetourafspraakRepository = new RetourafspraakRepository();


            ProductRepository = new ProductRepository();
            FactuurRepository = new FactuurRepository();
            RetourAfspraak retourAfspraak = Database.Database.Instance.JustPlacedRetourAfspraak;

            List<RetourItem> retourItems =
                RetourafspraakRepository.GetAllRetourAfspraakProductenByID(retourAfspraak.ID);

            LbRetourAfspraak.Items.Add("Retourafspraaknummer: " + retourAfspraak.ID.ToString());
            LbRetourAfspraak.Items.Add("Aanmaak datum: " + retourAfspraak.Datum.ToString());
            LbRetourAfspraak.Items.Add("-----------------------");

            
            foreach (RetourItem RetourItem in retourItems)
            {
                Product product = ProductRepository.GetByID(RetourItem.Product_ID);
                LbRetourAfspraak.Items.Add("Naam: " + product.Productnaam + " Prijs:" + product.Prijs);
                
            }
           
        }

        protected void BtTerugNaarHome_Click(object sender, EventArgs e)
        {
            Server.Transfer("/GUI/Homepagina.aspx");
        }
    }
}