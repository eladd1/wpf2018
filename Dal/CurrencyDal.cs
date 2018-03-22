using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Dal
{

    

    public class CurrencyDal:IDisposable
    {
        public SQLiteConnection con;
    
        public CurrencyDal()
        {
            con = new SQLiteConnection("MyData.db",false);
            con.CreateTable<CurrencyRate>();
        }

        public void Dispose()
        {
            con.Close();
        }

        public void addRate(CurrencyRate currencyRate)
        {
            con.Insert(currencyRate); 
        }

        public CurrencyRate getRate(string currencyName, DateTime date)
        {
            //set hours and minutes to zero. 
            DateTime day = date.Date;
            return con.Table<CurrencyRate>().Where(c => c.Name == currencyName && c.Date >= day).FirstOrDefault();
        }

        public IEnumerable<CurrencyRate> getRatesForDate(DateTime date)
        {
            return con.Table<CurrencyRate>().Where(c => c.Date == date);
        }

        public IEnumerable<CurrencyRate> getMultipleRates(IEnumerable<string> currencyNames, DateTime date)
        {
            return con.Table<CurrencyRate>().Where(c => c.Date == date);

        }

        public IEnumerable<CurrencyRate> getRatesForDateRange(string currencyName, DateTime start, DateTime end)
        {

            return con.Table<CurrencyRate>().Where(c => c.Date >= start && c.Date <= end && c.Name == currencyName)
                .GroupBy((e) => e.Date.Date)
                .Select((g) => g.FirstOrDefault());
                
        }

        public IEnumerable<CurrencyRate> getMultipleRatesForDateRange(IEnumerable<string> currencyNames, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public void addRates(IEnumerable<CurrencyRate> rates)
        {
            foreach (var rate in rates)
                con.Insert(rate);
        }

        public void updateRates(IEnumerable<CurrencyRate> rates)
        {
            foreach (var rate in rates)
            {
                rate.Date = rate.Date.Date;
                object[] insert_parameters = { rate.Date, rate.Name, rate.Value };
                con.Query<CurrencyRate>("insert OR REPLACE into CurrencyRate Values (?,?,?);", insert_parameters);
                //object[] update_parameters = { rate.Value, rate.Date, rate.Name };
                //CurrencyRate old_value = getRate(rate.Name, rate.Date);
                //if (old_value != null)
                //{
                    // row already exist - use update
                    //con.Update(rate);
                    //con.Query<CurrencyRate>("update CurrencyRate set Value = ? where Date like '%?%' and name = ?;", update_parameters);
                //}
                //else
                //{
                    // row not exist - use insert
                    //addRate(rate);
                    //con.Query<CurrencyRate>("insert into CurrencyRate Values (?,?,?);", insert_parameters);
                //}
            }
            con.Commit();
        }

        public MonthlyAverage getMonthlyAverage(int year, string month, string currencyName)
        {
            var result = con.Table<MonthlyAverage>().Where(m => m.Year == year && m.Month == month && m.CurrencyName == currencyName)
                .FirstOrDefault();
            return result;
        }
    }
}
