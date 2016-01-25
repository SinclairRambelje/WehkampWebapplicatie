using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wehkamp_Webapplicatie.GUI.PseudoDynamicASPMenuLink
{
    public partial class Heren_Jassen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //zorgt ervoor dat er een dynamische productenlijst pagina kan bestaan, ik heb dit zo gedaan omdat de enige andere weg via Java is. Want asp.net menu kan geen extra code meesturen.
            Database.Database.Instance.DynamicLink = "Heren jassen";
            Server.Transfer("/GUI/Productenlijst.aspx");

        }
    }
}