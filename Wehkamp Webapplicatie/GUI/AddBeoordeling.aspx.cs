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
    public partial class AddBeoordeling : System.Web.UI.Page
    {
        public BeoordelingRepository BeoordelingRepository { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BeoordelingRepository = new BeoordelingRepository();

            //voorkomt null text wanneer click event word uitgevoerd
            if (!IsPostBack)
            {
                TbTitel.Text = null;
                TbBericht.Text = null;
            }
        }

        protected void BtPlaatsBeoordeling_Click(object sender, EventArgs e)
        {
            
            //plaatst nieuwe beoordeling
            if (TbTitel.Text != null &&
                TbBericht.Text != null && RbWaardering.SelectedItem != null && TbTitel.Text.Length <= 30 && TbBericht.Text.Length <= 250)
            {
                BeoordelingRepository.AddBeoordeling(new Beoordeling(1, Database.Database.Instance.ProductBekijken.ID,Database.Database.Instance.LoggedAccount.Klantnummer,
                    Convert.ToInt32(RbWaardering.SelectedItem.Text), DateTime.Now,TbTitel.Text, TbBericht.Text));
                Server.Transfer("ProductBekijken.aspx");
            }
            else
            {
                LbSuccesCheck.Text = "Invulwaardes incorrect!";
            }
        }
    }
}