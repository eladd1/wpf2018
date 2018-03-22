using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dal;

namespace BL
{
    public class CurrencyBL: IDisposable
    {

        public CurrencyBL()
        {
            CurrencyDalInstance = new CurrencyDal();
            
        }

       public void Dispose()
        {
            CurrencyDalInstance.Dispose();
        }

        public void addRate(CurrencyRate currencyRate)
        {
            CurrencyDalInstance.addRate(currencyRate);
        }

        public CurrencyRate getRate(string currencyName, DateTime date)
        {
            return CurrencyDalInstance.getRate(currencyName, date);
        }

        public IEnumerable<CurrencyRate> getRatesForDate(DateTime date)
        {
            return CurrencyDalInstance.getRatesForDate(date);
        }

        public IEnumerable<CurrencyRate> getMultipleRates(IEnumerable<string> currencyNames, DateTime date)
        {
            return CurrencyDalInstance.getMultipleRates(currencyNames, date);
        }

        public IEnumerable<CurrencyRate> getRatesForDateRange(string currencyName, DateTime start, DateTime end)
        {
            return CurrencyDalInstance.getRatesForDateRange(currencyName, start, end);
        }

        public IEnumerable<CurrencyRate> getMultipleRatesForDateRange(IEnumerable<string> currencyNames, DateTime start, DateTime end)
        {
            return CurrencyDalInstance.getMultipleRatesForDateRange(currencyNames, start, end);
        }

        public void addRates(IEnumerable<CurrencyRate> rates)
        {
            CurrencyDalInstance.addRates(rates);
        }

        public void updateRates(IEnumerable<CurrencyRate> rates)
        {
            CurrencyDalInstance.updateRates(rates);
        }

        public IEnumerable<MonthlyAverage> getMonthlyAverages(string currency, int year)
        {
            List<string> months = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            foreach (var month in months)
            {
                var rates = getMonthlyAverage(currency, year, month);
                yield return getMonthlyAverage(currency, year, month);
            }
        }

        public MonthlyAverage getMonthlyAverage(string currency, int year, string month)
        {
            return CurrencyDalInstance.getMonthlyAverage(year, month, currency);
        }

        public IEnumerable<CurrencyRate> GetMainCurrencies()
        {
            List<CurrencyRate> result = new List<CurrencyRate>();
            foreach(CurrencyInformation c in CurrencyInformation.ImportantCurrencies)
            {
                result.Add(CurrencyDalInstance.getRate(c.Initials, DateTime.Now));
            }

            return result;
        }

        public double Convert(string source, string target, double sum)
        {
            
            double sourceValue = CurrencyBLInstance.getRate(source, DateTime.Now).Value;
            double targetValue = CurrencyBLInstance.getRate(target, DateTime.Now).Value;
            return sum*(targetValue/sourceValue);


        }

        public static CurrencyBL CurrencyBLInstance = new CurrencyBL();

        CurrencyDal CurrencyDalInstance;

    }
}


