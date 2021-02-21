using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.FactoryMethod
{

    /*WHEN TO USE
     * 1. When a class does not know which class of objects it must create.
     * 2. A class specifies its sub-classes to specify which objects to create.
     * 3. In programmer’s language (very raw form), you can use factory pattern where you have to create an object of any one of sub-classes depending on the data provided.
     */
    //Step 5: Client code
    public class FactoryMethodDP
    {
        public void FactoryMethod()
        {
            IUsers user = new AdmiFactory().CreatUser();
            Console.WriteLine(user.GetPermissions());
            Console.WriteLine(user.GetUserType());

            user = new ReadOnlyFactory().CreatUser();
            Console.WriteLine(user.GetPermissions());
            Console.WriteLine(user.GetUserType());
        }
    }

    //Step 1 : Product class
    public interface IUsers
    {
        public string GetPermissions();
        public string GetUserType();
        public void SendNotifications();
    }

    //Step 2 : Create Concrete Interface
    public class AdminUser : IUsers
    {
        public string GetPermissions()
        {
            return "ReadWrite";
        }

        public string GetUserType()
        {
            return "Admin";
        }

        public void SendNotifications()
        {
            Console.WriteLine("Notification sent to admin");
        }
    }

    public class ReadOnlyUser : IUsers
    {
        public string GetPermissions()
        {
            return "Read";
        }

        public string GetUserType()
        {
            return "ReadOnly";
        }

        public void SendNotifications()
        {
            Console.WriteLine("Notification sent to Readonly");
        }
    }

    //Step 3 : AbstractCreator
    public abstract class UserFactory
    {
        public abstract IUsers MakeUser();
        public IUsers CreatUser()
        {
            return this.MakeUser();
        }
    }


    //Step 4: Concreart Creator 
    public class AdmiFactory : UserFactory
    {
        public override IUsers MakeUser()
        {
            IUsers admin = new AdminUser();
            return admin;
        }
    }

    public class ReadOnlyFactory : UserFactory
    {
        public override IUsers MakeUser()
        {
            IUsers readOnly = new ReadOnlyUser();
            return readOnly;
        }
    }

}
