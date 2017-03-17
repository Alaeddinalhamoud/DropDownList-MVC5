using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Repository
{
    public class EmployeeRepository : IEmployee
    {
        EFDbContext context = new EFDbContext();
        public IList<Employee> GetEmployees
        {
            get
            {
                return context.Employees.ToList<Employee>();
             }
        }

        public void Delete(int? Id)
        {
            Employee emp = context.Employees.Find(Id);
            if(emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }

        }

        public Employee GetEmployee(int? Id)
        {
            return context.Employees.Find(Id);
        }

        public void Save(Employee employee)
        {
            if (employee.Id == 0)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            else
            {
                Employee dbEntry = context.Employees.Find(employee.Id);
                dbEntry.Id = employee.Id;
                dbEntry.FirstName = employee.FirstName;
                dbEntry.LastName = employee.LastName;
                dbEntry.GenderId = employee.GenderId;
                dbEntry.Salary = employee.Salary;
                context.SaveChanges();
            }
        }
    }
}