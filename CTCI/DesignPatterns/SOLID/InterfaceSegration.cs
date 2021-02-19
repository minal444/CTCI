using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.SOLID
{
    /*
     * Instead of fat interface just create multiple interface 
     * Client should not force to implement methods which they dont use
     */
    public class InterfaceSegration
    {

        
        public void GetProfile()
        {
            ClientProfile c = new ClientProfile();
            c.ClientHousehold(1);
            c.ClientDemograhics(1);

            ClientAppliction ca = new ClientAppliction();
            ca.GetInsurance(2);
        }
    }

    public interface IClientProfile
    {
        void ClientDemograhics(int clientId);
        void ClientHousehold(int clientId);
    }

    public interface IInsurance
    {
        void GetInsurance(int clientid);
    }

    public class ClientProfile : IClientProfile
    {
        public void ClientDemograhics(int clientId)
        {
            Console.WriteLine("Get Demogrpahics");
        }

        public void ClientHousehold(int clientId)
        {
            Console.WriteLine("Get Client household");
        }
    }
    public class ClientAppliction : IClientProfile, IInsurance
    {
        public void ClientDemograhics(int clientId)
        {
            Console.WriteLine("Get Demogrpahics");
        }

        public void ClientHousehold(int clientId)
        {
            Console.WriteLine("Get Client household");
        }

        public void GetInsurance(int clientid)
        {
            Console.WriteLine("Get Client Insurance");
        }
    }
}
