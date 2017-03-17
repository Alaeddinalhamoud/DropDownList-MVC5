using Dropdownlistmvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropdownlistmvc.Service
{
    public interface IEmployee
    {
        IList<Employee> GetEmployees { get; }
        void Save(Employee employee);
        void Delete(int? Id);

        Employee GetEmployee(int? Id);
    }
}