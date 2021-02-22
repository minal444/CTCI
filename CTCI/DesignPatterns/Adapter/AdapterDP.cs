using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.Adapter
{/*
  * Works as bridge between two incompatible interface to make them work together
  * In real workd this happend most of the time when dealing with two interfaces. Below are the types.
  *     1. Object Adapter : when there are two different language, like java or C# then use Object adapter
  *     2. Class Adapter : when both the class is in the same project then use class adapter
  * */
    //clent class can access only see Target interface 
    public class AdapterDP
    {
        public void GetClientProfile()
        {
            List<ClientProfile> lstCP = new List<ClientProfile>();
            ClientProfile cp = new ClientProfile(1, "Minal","Atena","Full");
            lstCP.Add(cp);
            cp = new ClientProfile(2, "Parth", "United", "Partial");
            lstCP.Add(cp);
            cp = new ClientProfile(3, "Maurya", "Sutter", "Temporary");
            lstCP.Add(cp);

            IClientProfile cpa = new ClientProfileAdaptoer();
            cpa.ProcessClaims(lstCP);

        }
    }
    //Step 1: Class - Model
    public class ClientProfile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Insurance { get; set; }
        public string Coverage { get; set; }

        public ClientProfile(int id, string name, string insurance, string coverage)
        {
            ID = id;
            Name = name;
            Insurance = insurance;
            Coverage = coverage;
        }

    }

    //Step 2: Adaptee 
    public class ThirdPartyInsurance
    {
        public void ProcessClaims(string[,] employeesArray)
        {
            for(int i=0; i <employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if(j==0)
                        Console.WriteLine("ID : " + employeesArray[i,j]);
                    if (j == 1)
                        Console.WriteLine("Name: " + employeesArray[i, j]);
                    if (j == 2)
                        Console.WriteLine("Insurance: " + employeesArray[i, j]);
                    if (j == 3)
                        Console.WriteLine("Coverage: " + employeesArray[i, j]);
                }
            }
        }
    }


    //Step3: Creating Target interface
    public interface IClientProfile
    {
        void ProcessClaims(IList<ClientProfile> clientProfiles);
    }

    //Step 4: Adapter
    //public class ClientProfileAdaptoer : ThirdPartyInsurance, IClientProfile --this is class adapter
    public class ClientProfileAdaptoer : IClientProfile
    {
        ThirdPartyInsurance thirdPartyInsurance = new ThirdPartyInsurance();
        public void ProcessClaims(IList<ClientProfile> clientProfiles)
        {
            //string[,] b = new string[clientProfiles.Count][];
            string[,] b = new string[clientProfiles.Count, 4];
            int row = 0;
            foreach (ClientProfile cp in clientProfiles)
            {

                b[row, 0] = cp.ID.ToString();
                b[row, 1] = cp.Name;
                b[row, 2] = cp.Insurance;
                b[row, 3] = cp.Coverage;
                row++;
            }

            thirdPartyInsurance.ProcessClaims(b);
        }
    }
}
