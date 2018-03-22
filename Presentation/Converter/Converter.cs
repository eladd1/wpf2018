using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BL;
using Models;

namespace Presentation.Converter
{
    public class Converter: INotifyPropertyChanged 
    {
        public Converter()
        {
            ConvertCommand = new DelegateCommand(Convert);
        }

        private string sourceCurrency = "USD";
        public string SourceCurrency
        {
            get { return sourceCurrency; }
            set
            {
                sourceCurrency = value;
                //update currency result value
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        private string targetCurrency = "USD";
        public string TargetCurrency
        {
            get { return targetCurrency; }
            set
            {
                targetCurrency = value;
                //update currency result value
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        private string sum = "0";
        public string Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                //update currency result value
            }
        }

        public string[] Currencies { get { return CurrencyInformation.ImportantCurrencies.Select((c)=>c.Initials).ToArray(); } }

        private string result;
        public string Result {
            get { return result; } set { result = value; PropertyChanged(this, new PropertyChangedEventArgs("Result")); }
          
        }

        public DelegateCommand ConvertCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static CurrencyBL CurrencyBLInstance = CurrencyBL.CurrencyBLInstance;

        public void Convert()
        {
            double result = CurrencyBLInstance.Convert(SourceCurrency, TargetCurrency, double.Parse(Sum));
            Result =  Math.Round(result, 3).ToString();
        }


        public class DelegateCommand : ICommand
        {
            private readonly Predicate<object> _canExecute;
            private readonly Action _execute;

            public event EventHandler CanExecuteChanged;

            public DelegateCommand(Action execute)
                           : this(execute, null)
            {
            }

            public DelegateCommand(Action execute,
                           Predicate<object> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                if (_canExecute == null)
                {
                    return true;
                }

                return _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute();
            }

            public void RaiseCanExecuteChanged()
            {
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

    }




}
