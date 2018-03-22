using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Models;
using CurrencyRatesGetter;
using Presentation;
using System.Windows;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            ICurrencyGetter c = new CurrencyGetter();
            CurrencyDal dal = new CurrencyDal();
            Task<IEnumerable<CurrencyRate>> answer = c.GetRates();
            answer.Wait();
            dal.addRates(answer.Result);

        }
    }
}
