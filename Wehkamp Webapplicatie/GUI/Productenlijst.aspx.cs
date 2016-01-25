using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Logic;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Kleding___Heren___Jassen : System.Web.UI.Page
    {
        
        public ProductRepository ProductRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ProductRepository = new ProductRepository();

            //laad juiste items
            ListView1.DataSource = ProductRepository.GetBySubCategorieString(Database.Database.Instance.DynamicLink);
            ListView1.DataBind();


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

        public void Bekijkproduct(object sender, EventArgs e)
        {
            
            Button myButton = (Button)sender;

            //het (tijdelijk) opslaan van het product dat bezichtigd gaat worden
            Database.Database.Instance.ProductBekijken =
                ProductRepository.GetBySubCategorieString(Database.Database.Instance.DynamicLink)
                    .Find(item => item.ID == Convert.ToInt32(myButton.CommandArgument.ToString()));
            
            Server.Transfer("ProductBekijken.aspx");
        }

        protected void listView_ItemCreated(object sender, ListViewItemEventArgs e)
        {

        }
    }


   

}