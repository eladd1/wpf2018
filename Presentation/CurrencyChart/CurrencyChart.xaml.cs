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
    /// <summary>
    /// Interaction logic for CurrencyChart.xaml
    /// </summary>
    public partial class CurrencyChart : UserControl
    {
        public CurrencyChart()
        {
            InitializeComponent();
            this.DataContext = new CurrencyChartVM();
        }

    }
}
