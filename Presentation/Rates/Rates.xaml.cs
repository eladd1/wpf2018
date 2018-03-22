using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using BL;
using Models;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Rates.xaml
    /// </summary>
    public partial class Rates : UserControl
    {
        public Rates()
        {
            InitializeComponent();       

            this.DataContext = new RatesVM();
        }

       

    }
        
    
}


