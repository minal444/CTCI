using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.SOLID
{
    //good example: https://code-maze.com/liskov-substitution-principle/
    class LiskovSubstitution
    {
        public void SubmitApp()
        {
            Application app = new InitialApplication();
            app.ApplicationName = "Initial Application Name";
            app.SubmitApplication();

            app = new UppdateApplication();
            app.ApplicationName = "Update Application Name";
            app.SubmitApplication();
        }
    }

    public abstract class Application
    {
        public abstract string ApplicationName { get; set; }
        public abstract void SubmitApplication();
        
    }

    public class InitialApplication : Application
    {
        public override string ApplicationName { get; set; }

        public override void SubmitApplication()
        {
            Console.WriteLine("Submitting the initial application --" + ApplicationName);
        }

        //public virtual void add()
        //{
        //    Console.WriteLine("add application --" + ApplicationName);
        //}
    }

    public class UppdateApplication : Application
    {
        public override string ApplicationName { get; set; }

        public override void SubmitApplication()
        {
            Console.WriteLine("Submitting the update application--" + ApplicationName);
        }
    }

    //public class DeleteApplication : InitialApplication
    //{
    //    public override string ApplicationName { get; set; }

    //    public override void add()
    //    {
    //        Console.WriteLine("Delete application --" + ApplicationName);
    //    }
    //}
}
