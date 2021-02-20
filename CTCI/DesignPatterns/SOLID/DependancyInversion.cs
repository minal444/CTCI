using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.SOLID
{
    /*
     * High level module should not depend on low level module. Both should depened upon abstraction. Also abstraction should not depened uplon detail.
     * Keep high level and low level module loosly coupled. For that both of them depend upon abstraction
     */
    public class DependancyInversion
    {
        EmployeeBusinessLogic employeeBusinessLogic= new EmployeeBusinessLogic();
        public void GetEmployee()
        {
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
        //EmployeeDataAccess _dataAccessFactory; //Without DI
        IEmployeeDataAccess _dataAccessFactory; //With DI
        public EmployeeBusinessLogic()
        {
            _dataAccessFactory = DataAccessFactory.GetEmployeeDataAccess();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return _dataAccessFactory.GetEmployeeetails(1);
        }
    }

    //Data access factory 
    public class DataAccessFactory
    {
        //public static EmployeeDataAccess GetEmployeeDataAccess() //without DI
        public static IEmployeeDataAccess GetEmployeeDataAccess() //DI 
        {
            return new EmployeeDataAccess();
        }

        //public static CustomerDataAccess GetCustomerDataAccess()
        //{
        //    return new CustomerDataAccess();
        //}
    }
    public class EmployeeDataAccess : IEmployeeDataAccess //added interface for DI 
    {
        public Employee GetEmployeeetails(int employeeID)
        {
            return new Employee
            {
                EmployeeId = employeeID,
                EmployeeName = "Minal",
                Department ="IT",
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
