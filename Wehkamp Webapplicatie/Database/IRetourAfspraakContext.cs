using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Database
{
    public interface IRetourAfspraakContext
    {
        List<RetourAfspraak> GetAll();

        List<RetourAfspraak> GetbyID(int AccountID);

        List<RetourItem> GetAllRetourAfspraakProductenByID(int RetourAfspraakID);

        List<RetourItem> GetAllRetourItems();

        void AddRetourAfspraak(RetourAfspraak retourAfspraak);

        void AddRetourItem(RetourItem RetourItem);
    }
}