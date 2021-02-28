using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.Observer
{
    /*
     * This DP is work on the priciple of publisher and Subscriber. Any change will happen to the Subject it will notify the Observer(subscriber) if the subsciber is registered for that.
     */
    public class Observer_PubSub
    {
        public void Observer()
        {
            //Create a Product with Out Of Stock Status
            Subject RedMI = new Subject();
            //User Anurag will be created and user1 object will be registered to the subject
            Observer user1 = new Observer("Anurag", RedMI);
            //User Pranaya will be created and user1 object will be registered to the subject
            Observer user2 = new Observer("Pranaya", RedMI);
            //User Priyanka will be created and user3 object will be registered to the subject
            Observer user3 = new Observer("Priyanka", RedMI);

            Console.WriteLine("Red MI Mobile current state : ");
            Console.WriteLine();
            // Now product is available
            RedMI.setAvailability("Available");
           // Console.Read();
        }
    }

    //Step 1 : Create Publisher - Subject 
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();

    }


    //Step 2: Concreate Publisher
    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        public void setAvailability(string availability)
        {
             
            Console.WriteLine("Availability changed from Out of Stock to Available.");
            NotifyObservers();
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Product Name : is Now available. So notifying all Registered users ");
            Console.WriteLine();
            foreach (IObserver observer in observers)
            {
                observer.NotifyObserver("avilability");
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }


    //Step 3 : Observer 
    public interface IObserver
    {

        void NotifyObserver(String message);

    }

    public class Observer :IObserver
    {
        public string UserName { get; set; }
        public Observer(string userName, ISubject subject)
        {
            UserName = userName;
            subject.RegisterObserver(this);
        }
        public void NotifyObserver(String message)
        {
            Console.WriteLine("Product " + message + " is available ");
        }
    }



}
