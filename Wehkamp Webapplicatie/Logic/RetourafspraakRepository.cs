using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wehkamp_Webapplicatie.Database;
using Wehkamp_Webapplicatie.Models;

namespace Wehkamp_Webapplicatie.Logic
{
    public class RetourafspraakRepository
    {
        public RetourAfspraakContext RetourAfspraakContext { get; set; }
        public RetourafspraakRepository()
        {
            RetourAfspraakContext = new RetourAfspraakContext();
        }
       public List<RetourAfspraak> GetAll()
       {
           throw new NotImplementedException();
       }

        public List<RetourAfspraak> GetbyID(int AccountID)
        {
            return RetourAfspraakContext.GetbyID(AccountID);
        }

        public List<RetourItem> GetAllRetourAfspraakProductenByID(int RetourAfspraakID)
        {
            return RetourAfspraakContext.GetAllRetourAfspraakProductenByID(RetourAfspraakID);
        }

        public List<RetourItem> GetAllRetourItems()
        {
            throw new NotImplementedException();
        }

        public void AddRetourAfspraak(RetourAfspraak retourAfspraak)
        {
            RetourAfspraakContext.AddRetourAfspraak(retourAfspraak);
        }

        public void AddRetourItem(RetourItem RetourItem)
        {
            RetourAfspraakContext.AddRetourItem(RetourItem);
        }


    }
}