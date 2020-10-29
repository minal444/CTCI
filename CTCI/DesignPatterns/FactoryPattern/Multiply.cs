using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.FactoryPattern
{
    class Multiply : ICalculate
    {
        public decimal Calculate(decimal num1, decimal num2)
        {
            return num1 * num2;
        }
    }
}
