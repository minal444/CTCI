using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.Bridge
{
    /*
     * Allows abstraction and implementation to be developed independantly 
     * Send message using any of the way using abstraction 
     */
    public class BridgeDP
    {
     
        public void Bridge()
        {
            AbstractMessage email = new LongMessage(new Email());
            email.SendMessage("This is email");
        }
    }

    //Step 1 : Creat abstract implementor

    public interface IMessageSender
    {
        public void SendMessage(string message);
    }


    //Step 2: create concrete implementor
    public class Email : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Send email");
        }
    }

    public class TextMessage: IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Send Test Message");
        }
    }

    //Step 3 : Create Abstraction
    public abstract class AbstractMessage
    {
        protected IMessageSender messageSender;
        public abstract void SendMessage(string message);
    }

    //Step 4 : concrete Abstract 
    public  class ShortMessage : AbstractMessage
    {
        public ShortMessage(IMessageSender ms)
        {
            this.messageSender = ms;
        }
        public override void SendMessage(string message)
        {
            messageSender.SendMessage(message);
        }
    }

    public class LongMessage : AbstractMessage
    {
        public LongMessage(IMessageSender ms)
        {
            this.messageSender = ms;
        }
        public override void SendMessage(string message)
        {
            messageSender.SendMessage(message);
        }
    }



    //Sample design Pattern
    //Step 1 : Abstract Implementor

    public enum ProgramType
    {
        PNS,
        NBS,
        Outcome
    }
    public interface IMailer
    {
        public void SendMailer();
    }


    //Step 2: concreate implementer
    public class PNSMailer : IMailer
    {
        public void SendMailer()
        {

        }
    }

    public class NBSMailer : IMailer
    {
        public void SendMailer()
        {

        }
    }

    public class OutcomeMailer : IMailer
    {
        public void SendMailer()
        {

        }
    }

    //Step 3 : AbstractFactory
    public abstract class MailerFactory
    {
        public IMailer GetMailerFactory(ProgramType program)
        {
            IMailer obj = null;
            if (program == ProgramType.NBS)
            {
                obj= new  NBSMailer();
            }
           else if (program == ProgramType.PNS)
            {
                obj = new PNSMailer();
            }
            else if(program == ProgramType.Outcome)
            {
                obj = new OutcomeMailer();
            }

            return obj;
        }
    }

}
