using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.FactoryPattern
{
    public class CalculateFactory 
    {
        public ICalculate GetCalculate(string type)
        {
            ICalculate obj = null;
            if(type.ToLower().Equals("add"))
            {
                obj = new Add();
            }
            else if (type.ToLower().Equals("substract"))
            {
                obj = new Add();
            }
            else if (type.ToLower().Equals("multiply"))
            {
                obj = new Multiply();
            }
            else if (type.ToLower().Equals("divide"))
            {
                obj = new Add();
            }
            else
            {
                Console.WriteLine("cannot implement");
            }
            return obj;

        }
    }
}
