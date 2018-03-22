using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for ConverterControl.xaml
    /// </summary>
    public partial class ConverterControl : UserControl
    {
        public ConverterControl()
        {
            InitializeComponent();
            this.DataContext = new Converter.Converter();


        }

        public string[] Currencies { get { return currencies; }  }

        private string[] currencies = { "EUR", "ILS" };


        
    }
}
