using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.SOLID
{
    class DependancyInversionExample2
    {  

        public void Notification()
        {
            
            //IMessage msg = new Email();
            //msg.ToAddress = "aa";
            List<IMessage> msg = new List<IMessage>();
            msg.Add(new Email() { Content = "content test", Subject = "subject test", ToAddress = "aaa@aaa.aa" });
            msg.Add(new SMS() {  Message ="SMS", PhoneNumber="111111"});
            Notification n = new Notification(msg);
            n.Send();
        }

    }

    public class Notification
    {
        ICollection<IMessage> _messages;

        public Notification(ICollection<IMessage> messages)
        {
            this._messages = messages;
        }

        public void Send()
        {
            foreach (var messgae in _messages)
            {
                messgae.SendMessage();
            }
        }
    }

    public interface IMessage
    {
        void SendMessage();
    }

    public class SMS : IMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public void SendMessage()
        {
            Console.WriteLine("Send SMS");
        }
    }

    public class Email : IMessage
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public void SendMessage()
        {
            Console.WriteLine("Send Email");
        }
    }
}
