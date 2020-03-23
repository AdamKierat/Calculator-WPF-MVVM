using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorMVVM.Core.Calculators.Tests
{
    [TestClass()]
    public class ExpressionCalculatorTests
    {
        [TestMethod()]
        public void ShlouldCalculate()
        {
            var expression = "2+2";
            var calculator = new ExpressionCalculator();
            var value = calculator.Calculate(expression);
            Assert.AreEqual(4,value);
        }
        
    }
}