using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CalculatorMVVM.Core.Calculators;
using CalculatorMVVM.ViewModels.Bases;
using Prism.Commands;
using Prism.Mvvm;

namespace CalculatorMVVM.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly ICalcualtor _calcualtor;
        private bool hasCalculated;
        private bool DoubledCalcuclatorOperation = false;
      
        

        

        public ShellViewModel(ICalcualtor calcualtor)
        {
            _calcualtor = calcualtor;
        }

        public string SetTitle { get; } = "Calculator WPF";

        public string _expression;
        public string Expression
        {
            get => _expression;
            set => SetProperty(ref _expression, value);
        }
        public DelegateCommand<string> AddNumberCommand { get; set; }
        public DelegateCommand EqualsCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand DelateLastCharCommand { get; set; }
        protected override void RegisterCommands()
        {
            AddNumberCommand = new DelegateCommand<string>(AddNumber);
            EqualsCommand = new DelegateCommand(Calculate);
            ClearCommand = new DelegateCommand(Clear);
            DelateLastCharCommand = new DelegateCommand(Delate);
        }

        public async void Calculate()
        {

            if (!(String.IsNullOrEmpty(Expression)))
            {
                
                if (!(_calcualtor.Calculate(Expression).ToString("N2") == "0,00"))
                {
                    Expression = _calcualtor.Calculate(Expression).ToString("N2");
                }
                else
                {
                    Expression = "Error";
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    Clear();
                }
                hasCalculated = true;
            }


        }
        private void AddNumber(string buttonValue)
        {
            if (!(String.IsNullOrEmpty(Expression)))
            {
                if (!((buttonValue == "*" || buttonValue == "/" || buttonValue == "-"||buttonValue == "+") &&
                      (Expression[Expression.Length - 1].ToString() == "*" || Expression[Expression.Length - 1].ToString() == "/" ||
                       Expression[Expression.Length - 1].ToString() == "-" ||
                       Expression[Expression.Length - 1].ToString() == "+")))
                {
                    Expression += buttonValue.ToString();
                }
            }
            else
            {
                Expression += buttonValue.ToString();

            }
            if (hasCalculated)
            {
                Clear();
                hasCalculated = false;
            }

           
        }
        private void Clear()
        {
            Expression = string.Empty;

        }
        public void Delate()
        {
            if (!(String.IsNullOrEmpty(Expression)))
            {
                string tmp = Expression;
                Expression = tmp.Remove(Expression.Length - 1).ToString();
            }
        }

    }
}
