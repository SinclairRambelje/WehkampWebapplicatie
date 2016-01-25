using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Platform
    {
        public int ID { get; set; }
        public string Platformnaam { get; set; }

        public Platform(int id, string platformnaam)
        {
            ID = id;
            Platformnaam = platformnaam;
        }
    }
}