using Dropdownlistmvc.Data;
using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dropdownlistmvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee EmpRepository;
        private readonly IGender GenderRepository;

        public EmployeeController(IEmployee EmpRepo, IGender GenderRepo)
        {
            EmpRepository = EmpRepo;
            GenderRepository = GenderRepo;
        }
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> model;
            model = EmpRepository.GetEmployees;
           // model.Genders = GenderRepository.GetGenders;
            return View(model);
        }
        public ActionResult AddEmployee()
        {
            Employee Emp=new Employee();
            Emp.Id = 0;
            Emp.GendersEnum = GenderRepository.GetGenders;
            return View("Edit",Emp);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Employee Emp = EmpRepository.GetEmployee(Id);
            Emp.GendersEnum = GenderRepository.GetGenders;
            return View(Emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee data)
        {
            if (ModelState.IsValid)
            {
                EmpRepository.Save(data);
                TempData["message"] = "Save";
                return RedirectToAction("Index");
            }
            //Refill DropDL again 
            data.GendersEnum = GenderRepository.GetGenders;
            return View(data);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }
            EmpRepository.Delete(Id);
            TempData["message"] = "Deleted";
            return RedirectToAction("Index");
        }
    }
}