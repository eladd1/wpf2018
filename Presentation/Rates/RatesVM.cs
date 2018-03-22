using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using BL;
using Models;

namespace Presentation
{
    public class RatesVM
    {
        public RatesVM()
        {
            CurrencyInformationCollection = new List<CurrencyInformation>();
            foreach (CurrencyInformation c in CurrencyInformation.ImportantCurrencies)
            {
                CurrencyRate rate = CurrencyBLInstance.getRate(c.Initials, DateTime.Now);
                CurrencyInformation information = new CurrencyInformation(c.Initials, c.Description, c.PathToImage);
                information.Rate = rate;
                information.Rate.Value = Math.Round(information.Rate.Value, 3);
                CurrencyInformationCollection.Add(information);

            }
        }



        public List<CurrencyInformation> CurrencyInformationCollection { get; set; }

        public static CurrencyBL CurrencyBLInstance = CurrencyBL.CurrencyBLInstance;
    }
    
}
