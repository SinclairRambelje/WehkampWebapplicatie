using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wehkamp_Webapplicatie.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string GenreNaam { get; set; }

        public Genre(int id, string genreNaam)
        {
            ID = id;
            GenreNaam = genreNaam;
        }
    }
}