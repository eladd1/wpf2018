using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CurrencyInformation
    {
        public string Initials { get; set; }
        public string Description { get; set; }
        public string PathToImage { get; set; }
        public CurrencyRate Rate { get; set; } 

        public CurrencyInformation(string initials, string description, string pathToImage)
        {
            Initials = initials;
            Description = description;
            PathToImage = pathToImage;
            Rate = null;
        }

        public static CurrencyInformation[] ImportantCurrencies =
        {
            new CurrencyInformation("USD", "U.S. Dollar", "/Resources/dollar.png"),
            new CurrencyInformation("ILS", "Israeli New Sheckel", "/Resources/dollar.png"),
            new CurrencyInformation("EUR", "Euro", "/Resources/euro.png"),
            new CurrencyInformation("JPY", "Japanese Yen", "/Resources/yen.png"),
            new CurrencyInformation("CHF", "Swiss Franc", "/Resources/franc.png"),
            new CurrencyInformation("GBP", "U.K. Pound", "/Resources/pound.png"),

        };
    }

   
}
