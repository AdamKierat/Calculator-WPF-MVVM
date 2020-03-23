using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorMVVM.ViewModels.Bases;
using Prism.Commands;
using Prism.Mvvm;

namespace CalculatorMVVM.ViewModels
{
    public class ShellViewModel:ViewModelBase
    {
        public ShellViewModel()
        {

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
        protected override void RegisterCommands()
        {
            AddNumberCommand = new DelegateCommand<string>(AddNumber);
            ClearCommand = new DelegateCommand(Clear);
         
        }

        private void AddNumber(string buttonValue)
        {
            Expression += buttonValue.ToString();
        }

        private void Clear()
        {
            Expression = string.Empty;
        }
       
    }
}
