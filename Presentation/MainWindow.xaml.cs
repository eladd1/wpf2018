using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CurrencyRatesGetter;
using BL;
using Models;
using System.IO;
using System.Timers;
using System.Windows.Input;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            startTimer();
            InitializeComponent();
        }

        public void startTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 20);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            UpdateDatebase();
            // Forcing the CommandManager to raise the RequerySuggested event
            //CommandManager.InvalidateRequerySuggested();
        }

        public  void UpdateDatebase()
        {
            ICurrencyGetter c = new CurrencyGetter();
            CurrencyBL bl = new CurrencyBL();
            IEnumerable<CurrencyRate> answer = c.GetRatesSync();
            //bl.addRates(answer);
            bl.updateRates(answer);
        }

        
    }
}