using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wehkamp_Webapplicatie.GUI.Bestelproces
{
    public partial class Bestel___1___Verzenadres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            //weergeeft je adresgegevens
            lBIngelogdeAdres.Items.Add(Database.Database.Instance.LoggedAccount.Voornaam.ToString() + " " + Database.Database.Instance.LoggedAccount.Achternaam.ToString());
            lBIngelogdeAdres.Items.Add(Database.Database.Instance.LoggedAccount.Adres.ToString() );
            lBIngelogdeAdres.Items.Add(Database.Database.Instance.LoggedAccount.Woonplaats.ToString() + " " + Database.Database.Instance.LoggedAccount.Postcode.ToString());
            
            //weergeeft de datum van morgen, overmorgen en drie dagen verder
            DDListLeverdatum.Items.Add(DateTime.Today.AddDays(1).ToString("dd-MM-yyyy"));
            DDListLeverdatum.Items.Add(DateTime.Today.AddDays(2).ToString("dd-MM-yyyy"));
            DDListLeverdatum.Items.Add(DateTime.Today.AddDays(3).ToString("dd-MM-yyyy"));
            
        }

        protected void BtGaNaarStap2_Click(object sender, EventArgs e)
        {
            //slaat verzendatum voor de factuur op
            if (DDListLeverdatum.SelectedIndex == 0)
            {
                Database.Database.Instance.VerzendDatum = DateTime.Today.AddDays(1);
            }
            else if (DDListLeverdatum.SelectedIndex == 0)
            {
                Database.Database.Instance.VerzendDatum = DateTime.Today.AddDays(2);
            }
            else if (DDListLeverdatum.SelectedIndex == 0)
            {
                Database.Database.Instance.VerzendDatum = DateTime.Today.AddDays(3);
            }
                Server.Transfer("/GUI/Bestelproces/Bestel - 2 - Betaalwijze Selecteren.aspx");
        }

        
    }
}