using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.DependancyInjection
{
    /*
     * To make application loosely coupled. Any dependancy object will be passed from dependant class as injection.
     * Only differance of DInversion and DI is that in DI there is a dependancy passed as parameter while in DInversion its creat the new object in DataAccessFactoryClass
    */
    public     class DependancyInjectionDP
    {
        public void GetEmployee()
        {
            EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic(new EmployeeDataAccess());
            Employee emp = new Employee();
            emp = employeeBusinessLogic.GetEmployeeDetails(1);
            Console.WriteLine(emp.Department);
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }


    public class EmployeeBusinessLogic
    {
        IEmployeeDataAccess _dataAccessFactory; 
        public EmployeeBusinessLogic(IEmployeeDataAccess dataAccess)
        {
            _dataAccessFactory = dataAccess;
        }

        public Employee GetEmployeeDetails(int id)
        {
            return _dataAccessFactory.GetEmployeeetails(1);
        }
    }

    
    public class EmployeeDataAccess : IEmployeeDataAccess //added interface for DI 
    {
        public Employee GetEmployeeetails(int employeeID)
        {
            return new Employee
            {
                EmployeeId = employeeID,
                EmployeeName = "Minal",
                Department = "IT",
                Salary = 111111
            };
        }
    }

    //For DI Dependamcy Injection we need to create Interface or Abastraction
    public interface IEmployeeDataAccess
    {
        public Employee GetEmployeeetails(int employeeID);
    }
    //public class CustomerDataAccess
    //{
    //    public void GetCustomers()
    //    {
    //        Console.WriteLine("Get Customers");
    //    }
    //}
}
