using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.SOLID
{
    //SOLID Design Principles
        //Maintanability
        //Testability
        //Flexibility in terms of new anhancement or change
        //Parellal development 
    public class SingleResponsibility 
    {
        public void Purchase()
        {
            Invoice invoice= new Invoice();
            invoice.AddInvoice();

            
        }
    }

    public class Invoice
    {
        private Logger fileLogger;
        private Notifications emailSender;
        public Invoice()
        {
            fileLogger = new Logger();
            emailSender = new Notifications();
        }
        public void AddInvoice()
        {
            try {
                fileLogger.Info("(Add Invoice Method");
                emailSender.SendEmail();
                Console.WriteLine("Invoice has been added ");
            }
            catch(Exception ex)
            {
                fileLogger.Error(ex,"Error from AddInvoice");
            }
            
        }
    }

    public class Notifications
    {
        public string fromEmail { get; set; }
        public string toEmail{ get; set; }
        public string Subject { get; set; }
        public string Body{ get; set; }
        public void SendEmail()
        {
            Console.WriteLine("Email has been sent sucessfully");
        }
    }

    public class Logger
    {
        public void Info(string str)
        {
            Console.WriteLine("Information -- "+ str );
        }

        public void Error(Exception ex, string str)
        {
            Console.WriteLine("Error -- " + ex.Message + "---" + str);
        }


        public void Debug(string str)
        {
            Console.WriteLine("Debug -- " + str);
        }
    }
}
