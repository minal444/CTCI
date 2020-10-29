using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTCI.DesignPatterns.FactoryPattern
{
    public class ClientFactory
    {
        public void Calculate()
        {
            Console.WriteLine("Enter num1");
            decimal num1, num2;
            bool result;
            result = Decimal.TryParse(Console.ReadLine(), out num1);
            Console.WriteLine("Enter num2");
            result = Decimal.TryParse(Console.ReadLine(), out num2);

            CalculateFactory factory = new CalculateFactory();
            Console.WriteLine("Enter operation");
            ICalculate obj =  factory.GetCalculate(Console.ReadLine());
            decimal output = obj.Calculate(num1, num2);
            Console.WriteLine(output);


        }
    }
}
