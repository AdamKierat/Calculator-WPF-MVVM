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

        private string _calculatorTextChange;
        private string CalculatorTextChange
        {
            get { return _calculatorTextChange; }
            set { SetProperty(ref _calculatorTextChange, value); }
        }

        public DelegateCommand AddNumberCommand { get; set; }

        protected override void RegisterCommands()
        {
            AddNumberCommand = new DelegateCommand(AddNumber);
        }

        private void AddNumber()
        {
            CalculatorTextChange = "5";
        }
    }
}
