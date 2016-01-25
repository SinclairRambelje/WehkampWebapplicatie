using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wehkamp_Webapplicatie.GUI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //logt de gebruiker uit, en zend hem terug naar de homepagina
            Database.Database.Instance.LoggedAccount = null;
            Server.Transfer("Homepagina.aspx");
        }
    }
}