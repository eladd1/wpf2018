using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Models;

namespace CurrencyRatesGetter
{
    /*connects to the internet to get currency rates */
    public class CurrencyGetter: ICurrencyGetter
    {
        static string SourceUri = "http://apilayer.net/api/live";
        static string AccessKey = "63b7b7265465cb8335d5f08ebac0ac43";
        static string[] CurrenciesToPoll = { "GBP", "EUR", "JPY", "CHF", "USD", "ILS" };
        static HttpClient client = new HttpClient();

        public CurrencyGetter()
        {
           
        }
        
        /* returns a list of currencues and their value today*/
        public async Task<IEnumerable<CurrencyRate>> GetRates()
        {
           
            List<CurrencyRate> rates = new List<CurrencyRate>();
            var builder = new UriBuilder(SourceUri) {Port=-1 };
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["access_key"] = AccessKey;
            query["currencies"] = string.Join(",",CurrenciesToPoll);
            builder.Query = query.ToString();
            string url = builder.ToString();
 
            HttpResponseMessage response =  await client.GetAsync(url).ConfigureAwait(false);
            
            if (response.IsSuccessStatusCode)
            {
                string ratesString = await response.Content.ReadAsStringAsync();
                JObject ratesJsonObject = (JObject)JObject.Parse(ratesString)["quotes"];
                foreach(JProperty p in ratesJsonObject.Properties())
                {
                    //The result is in format USD***  where *** is the currency we want. we only take the ***
                    rates.Add(new CurrencyRate(p.Name.Substring(3), double.Parse(p.Value.ToString()),DateTime.Now));
                }
              
                
            }
            return rates;
        }



        public IEnumerable<CurrencyRate> GetRatesSync()
        {
            var rates = GetRates();
            rates.Wait();
            return rates.Result;

        }



        
    }
}
