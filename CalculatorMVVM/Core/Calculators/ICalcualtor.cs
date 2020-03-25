using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVVM.Core.Calculators
{
    public interface ICalcualtor
    {
        double Calculate(string expression);
        bool last_character_checking(string expression);
    }
}
