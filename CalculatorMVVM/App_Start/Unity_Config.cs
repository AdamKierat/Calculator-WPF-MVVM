using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalculatorMVVM.Core.Calculators;
using Unity;

namespace CalculatorMVVM.App_Start
{
    public static class  Unity_Config
    {
        public static IUnityContainer RegisterInstances(this IUnityContainer container)
        {
            container.RegisterType<ICalcualtor, ExpressionCalculator>();
            return container;
        }

    }
}
