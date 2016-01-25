using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class ZoekPagina : System.Web.UI.Page
    {
        public ProductRepository ProductRepository { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductRepository = new ProductRepository();

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

        protected void BtZoekOpNaam_Click(object sender, EventArgs e)
        {
            //zoek op basis van naam producten
            Database.Database.Instance.RecensteZoekOpdracht = TbZoek.Text;
            ListView1.DataSource = ProductRepository.GetByNameLike(TbZoek.Text);
            ListView1.DataBind();
        }

        public void Bekijkproduct(object sender, EventArgs e)
        {
            //laat de productpagina zien van product
            Button myButton = (Button)sender;

            try
            {
                Database.Database.Instance.ProductBekijken =
               ProductRepository.GetByNameLike(Database.Database.Instance.RecensteZoekOpdracht)
                   .Find(item => item.ID == Convert.ToInt32(myButton.CommandArgument.ToString()));
            }
            catch (Exception)
            {

                Database.Database.Instance.ProductBekijken =
               ProductRepository.GetBySubCategorieStringLike(Database.Database.Instance.RecensteZoekOpdracht)
                   .Find(item => item.ID == Convert.ToInt32(myButton.CommandArgument.ToString()));
            }
            

            Server.Transfer("ProductBekijken.aspx");
        }

        protected void BtZoekOpCategorie_Click(object sender, EventArgs e)
        {
            //zoekt producten op basis van catogorienaam die je invoerd
            Database.Database.Instance.RecensteZoekOpdracht = TbZoek.Text;
            ListView1.DataSource = ProductRepository.GetBySubCategorieStringLike(TbZoek.Text);
            ListView1.DataBind();
        }
    }
}