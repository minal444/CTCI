using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.FactoryPattern
{
    public interface ICalculate
    {
        public decimal Calculate(decimal num1 , decimal num2);
    }
}
