using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.OOPS.CallCenter
{
    /* callcenter
     * Incoming call
     *      IF respondent is available then take it 
     *      ELSE escalate to Manager 
     *      
     *      IF Manager is available then take it
     *      ELSE ecalate to directore 
     *      
     *      What if director is not available then should we add to Queue?
     *    
     * How many Total employees are there?
     * Employee
     * IsAvailable 
     *      Respondent = 10
     *          ReciveCall()
     *          EscalateCall()    
     *      
     *      Manager = 2
     *          ReciveCall()
     *          EscalateCall()
     *          
     *      Director = 1 
     *          ReciveCall()
     *          NOOFTIMES WAIT 
     *              
     *      SYSTEM :
     *          dispatchCall();
     *          AddToQueue()
     * 
     *
     * */
    class CallCenter
    {
        public const int NO_OF_RESPONDENT = 10;
        public const int NO_OF_MANAGER = 2;
        public const int NO_OF_DIRECTOR = 1;
    }
     
    public abstract class Employee
    {
        private Call currCall = null;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsFree()
        {
            return currCall == null;
        }

        public void ReciveCall()
        {
        }

        public void CompleteTheCall()
        {
           
        }

        public void AssignCall()
        {
        }
        public void EscalateCall()
        {

        }
    }

    public class Respondant : Employee
    {
    }
    public class Manager : Employee
    {
        
    }
    public class Director : Employee
    {
         
    }

    public class Call
    {

        Employee emp;
        private Caller caller;
        public Call(Caller c)
        {
            caller = c;
        }
        
    }

    public class CallHandler
    {
        List<List<Employee>> employeeLevels;

        public Employee GetAvailableEmployee(Call call)
        {
            return new Respondant();
        }

        public void DispatchCall(Call c)
        {
            Employee e = GetAvailableEmployee(c);
            if(e!=null)
            {
                e.ReciveCall();
                
            }
        }

        public void AddToQueue()
        {

        }
    }

    public class Caller
    {
        public string Phone { get; set; }
    }

}
