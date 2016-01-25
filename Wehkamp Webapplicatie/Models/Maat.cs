using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Maat
    {
        public int ID { get; set; }
        public string MerkGroote { get; set; }

        public Maat(int id, string merkGroote)
        {
            ID = id;
            MerkGroote = merkGroote;
        }
    }
}