using System;
using System.Collections.Generic;
using System.Text;
namespace Models
{
    public class CurrencyRate
    {
        private string name;
        private double value;
        private DateTime date;

        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
        public DateTime Date { get => date; set => date = value; }

        public CurrencyRate() { }
        public CurrencyRate(string name, double value, DateTime date)
        {
            Name = name;
            Value = value;
            Date = date;
        }
    }
}
