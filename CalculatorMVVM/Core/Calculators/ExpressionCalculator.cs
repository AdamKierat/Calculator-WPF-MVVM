using System;
using System.Data;

namespace CalculatorMVVM.Core.Calculators
{
    public class ExpressionCalculator:ICalcualtor
    {
        public double Calculate(string expression)
        {
           
            if (!(expression == string.Empty))
            {
                if (expression[0] == '*' || expression[0] == '/' || expression[0] == '+' || expression[0] == '-' || expression[0] == ',' || expression[0] == '0'||
                    expression[expression.Length - 1] == '*' || expression[expression.Length - 1] == '/' || expression[expression.Length - 1] == '+' || expression[expression.Length - 1] == '-' || expression[expression.Length - 1] == ','|| expression[expression.Length - 1]=='0')
                {
                    return 0;
                }
                else
                {
                    {
                        var dataTable = new DataTable();
                        var value = dataTable.Compute(expression, "");
                        return Convert.ToDouble(value);
                    }


                }
            }

            return 0;
        }
    }
}