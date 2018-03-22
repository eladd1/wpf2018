using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Threading.Tasks;

namespace CurrencyRatesGetter
{
    public interface ICurrencyGetter
    {
        Task<IEnumerable<CurrencyRate>> GetRates(); 
        IEnumerable<CurrencyRate> GetRatesSync();
    }
}
