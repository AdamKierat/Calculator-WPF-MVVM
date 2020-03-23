using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalculatorMVVM.Core.Calculators;
using CalculatorMVVM.ViewModels.Bases;
using Prism.Commands;
using Prism.Mvvm;

namespace CalculatorMVVM.ViewModels
{
    public class ShellViewModel:ViewModelBase
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
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand EqualsCommand { get; set; }
        public DelegateCommand LastCharacterDelate { get; set; }
        protected override void RegisterCommands()
        {
            AddNumberCommand = new DelegateCommand<string>(AddNumber);
            ClearCommand = new DelegateCommand(Clear);
            EqualsCommand = new DelegateCommand(Calculate);
            LastCharacterDelate = new DelegateCommand(Delate);
        }

        
        public void Calculate()
        {
            
            if(!(String.IsNullOrEmpty(Expression)))
            { 
            Expression = _calcualtor.Calculate(Expression).ToString("N2");
            hasCalculated = true;
            }

        }
        private void AddNumber(string buttonValue)
        {
        
            if (hasCalculated)
            {
                Clear();
                hasCalculated = false;
            }

            Expression += buttonValue.ToString();
        }

        private void Clear()
        {
            Expression = string.Empty;
        }
        public void Delate()
        {
            Expression = Expression.Remove(Expression.Length - 1);
        }
    }
}
