using System;
using System.Data;

namespace CalculatorMVVM.Core.Calculators
{
    public class ExpressionCalculator:ICalcualtor
    {
        public double Calculate(string expression)
        {
            var dataTable = new DataTable();
            var value = dataTable.Compute(expression, "");
            return Convert.ToDouble(value);
        }
    }
}