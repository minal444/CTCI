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

        //Real Time example of the factory design pattern. I have used once where i need to get the permissions and based on that send notification email.
        //passing user type in parameter
            //If user is admin then sendemail with different way.
            //If user is not-admin then sendemail differnt way 
        //Ways to create factory pattern
            //1 create interface for base methods
            //2 create subclass and implement the interface
            //3 create facotory class which retrun interface as object. Take parameter and based on that it will return the object 
            //4 client class will use the Interface object 
    }
}
