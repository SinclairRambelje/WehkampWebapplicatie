using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wehkamp_Webapplicatie.Database;


namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            Label LblHeader = this.Master.FindControl("LbWelkom") as Label;

            LblHeader.Text = "Incident status";

        }
    }
}