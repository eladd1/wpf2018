using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MonthlyAverage
    {
        public MonthlyAverage() { }
        public MonthlyAverage(string month, int year, string currencyName, double value)
        {
            Month = month;
            Year = year;
            CurrencyName = currencyName;
            Value = value;
        }

        string month;
        int year;
        string currencyName;
        double value;

        public string Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        public string CurrencyName { get => currencyName; set => currencyName = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
