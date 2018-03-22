using System;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;
using BL;
using Models;
using System.ComponentModel;

namespace Presentation
{
    public class CurrencyChartVM: INotifyPropertyChanged
    {
        public CurrencyChartVM()
        {

            CurrencyBlInstance = new CurrencyBL();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title="",
                    Stroke = System.Windows.Media.Brushes.Red,
                    Fill = null,
                    LineSmoothness = 0.2,
                    PointGeometry=null
                }
            };

            CurrencyNames = new List<string>() { "GBP", "EUR", "JPY", "CHF", "USD", "ILS" };
            RangeOptions = new List<string> { "Daily", "Monthly" };
            Monthes = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            YFormatter = value => value.ToString("C");
            UpdateValues();
        }

        //Combobox options
        public List<string> CurrencyNames { get; set; }
        public List<string> RangeOptions { get; set; }
        public List<int> Monthes { get; set; }

        //Graph definitions
        public SeriesCollection SeriesCollection { get; set; }
        private List<string> labels;
        public List<string> Labels
        { get { return labels; } set
            {
                labels = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("labels"));
                }
            }
               
        }
        public Func<double, string> YFormatter { get; set; }

        //services
        public BL.CurrencyBL CurrencyBlInstance;

        private string currencyName = "ILS";
        public string CurrencyName
        {
            get => currencyName;
            set
            {
                currencyName = value;
                UpdateValues();
            }
        }

        private string year = "2015";
        public string Year
        {
            get { return year; }
            set
            {
                year = value;
                UpdateValues();
            }
        }

        private string month = "1";
        public string Month
        {
            get { return month; }
            set { month = value; UpdateValues(); }
        }

        private string range = "Monthly";
        public string Range
        {
            get { return range; }
            set { range = value; UpdateValues(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //Enter data into graph
        public void UpdateValues()
        {
            if (Range == "Daily")
            {
                IEnumerable<CurrencyRate> rates = CurrencyBlInstance.getRatesForDateRange(
                    CurrencyName,
                    new DateTime(int.Parse(Year), int.Parse(Month), 1),
                    new DateTime(int.Parse(Year), int.Parse(Month), DateTime.DaysInMonth(int.Parse(Year), int.Parse(Month))));
                Labels = rates.Select((c) => c.Date.Date.ToShortDateString()).ToList();
                SeriesCollection[0].Values = new ChartValues<double>(rates.Select((c) => c.Value));
                PropertyChanged(this, new PropertyChangedEventArgs("Labels"));
            }
            else
            {
                Labels = new List<string>();
                SeriesCollection[0].Values = new ChartValues<double>();

                var averages = CurrencyBlInstance.getMonthlyAverages(CurrencyName, int.Parse(Year));
                foreach (var average in averages)
                {
                    if (average != null)
                    {
                        Labels.Add(average.Month);
                        SeriesCollection[0].Values.Add(average.Value);
                    }
                }

            }
        }



    }
}
