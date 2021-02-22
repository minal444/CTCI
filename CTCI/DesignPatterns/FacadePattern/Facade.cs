using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.FacadePattern
{
    /*
     * Used when hide the complexity of the system and only provide the interface to the client to use the system
     * Its wrapper sits on top of the subsystems
     */
    public class Facade
    {
        public void ApplicationSumission()
        {
            Application a = new Application();
            a.SubmitApplication();
        }
    }

    //Step1: Creating subsystems
    //Get Products 
    public class Eligibility
    {
        public void CalculateEligibility()
        {
            Console.WriteLine("Eligibility is calculated");
        }
    }
    //Payment
    public class AssignAvailableUser
    {
        public void AssignUser()
        {
            Console.WriteLine("User has been assigned for work item");
        }
    }

    //Invoice
    public class InsuranceDataExchange
    {
        public void ExchangeData()
        {
            Console.WriteLine("Data has been exchange for insurance");
        }
    }

    //Step 2: Create facade
    public class Application
    {
        public void SubmitApplication()
        {
            Console.WriteLine("Applicaion submission started");
            Eligibility eligibility = new Eligibility();
            eligibility.CalculateEligibility();
            AssignAvailableUser review = new AssignAvailableUser();
            review.AssignUser();
            InsuranceDataExchange dataexchaneg = new InsuranceDataExchange();
            dataexchaneg.ExchangeData();
            Console.WriteLine("Application submitted Successfully");
        }
    }

}
