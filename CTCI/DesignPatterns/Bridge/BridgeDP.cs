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

}
