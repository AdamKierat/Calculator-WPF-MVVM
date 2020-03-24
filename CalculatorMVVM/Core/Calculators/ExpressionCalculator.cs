using System;
using System.Data;

namespace CalculatorMVVM.Core.Calculators
{
    public class ExpressionCalculator : ICalcualtor
    {
        public double Calculate(string expression)
        {

            if (!(String.IsNullOrEmpty(expression)))
            {
                if (last_character_checking(expression)) return 0;

                else
                {
                    var dataTable = new DataTable();
                    var value = dataTable.Compute(expression, "");
                    return Convert.ToDouble(value);
                }
            }

            return 0;
        }

        public bool last_character_checking(string expression)
        {
            if (expression[0] == '*' || expression[0] == '/' || expression[0] == '+' || expression[0] == '-' ||
                expression[0] == ',' || expression[0] == '0' || expression[0] == '.' ||
                expression[expression.Length - 1] == '*' || expression[expression.Length - 1] == '/' ||
                expression[expression.Length - 1] == '+' || expression[expression.Length - 1] == '-' ||
                expression[expression.Length - 1] == ',' || expression[expression.Length - 1] == '0'|| expression[expression.Length-1] == '.')
            {
                return true;
            }
            else return false;

        }
    }
}
