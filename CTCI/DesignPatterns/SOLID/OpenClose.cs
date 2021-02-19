using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.SOLID
{
    /*
     * -------------------If not follwed then -------------------
     * Existing class modified so need to test entier functionality 
     * Need to inform QA for entier validation
     * Violate Single Responsibility Principle as well
     * Difficult to maintain if there are many functionality in one class
     * 
     * 
     * -------------------How to implement -------------------
     * Either create derived class and inherit from base class for new functionality
     * Allow client to access the original class with abstract interface
     */
    public class OpenClose
    {
        public void GetInvoiceDiscount()
        {
            InvoiceOC finalInvoice = new FinalInvoice();
            InvoiceOC proposed = new ProposedInvoice();

            Console.WriteLine(finalInvoice.GetInvoiceDiscount(1000));
            Console.WriteLine(proposed.GetInvoiceDiscount(1000));
        }

    }

    public class InvoiceOC
    {
        public virtual double GetInvoiceDiscount(double amount)
        {
            return amount - 10;
        }

    }

    public class FinalInvoice : InvoiceOC
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 50;
        }
    }
    public class ProposedInvoice : InvoiceOC
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 30;
        }
    }
}
