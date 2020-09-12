using DotNetCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTesting.Controllers
{
    public class HomeController:Controller
    {
        private IEmployeeRepository _employeeRepository;

        //Loosely coupled with DI
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Less loosely coupled without DI
        //public HomeController()
        //{
        //    _employeeRepository = new MockEmployeeRepository();
        //}

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        //public JsonResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}
        //Return Xml result
        //public ObjectResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return new ObjectResult(model);
        //}

        //Return View result
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewData["Employee"] = model;
            ViewData["PageTitle"] = "Employee";
            return View();
        }

        //Return View with different path
        public ViewResult Details1()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View("MyViews/test.cshtml");
        }
    }
}
