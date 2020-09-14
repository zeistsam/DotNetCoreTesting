using DotNetCoreTesting.Models;
using DotNetCoreTesting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTesting.Controllers
{
    [Route("[controller]/[action]")]
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
        [Route("~/Home")]
        [Route("~/")]
        public ViewResult Index()
        {
            var model= _employeeRepository.GetAllEmployees();
            return View(model);
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

        //Return View result using Strongly Type Views
        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"

            };
           
            return View(homeDetailsViewModel);
        }


        //Return View with different path
        public ViewResult Details1()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View("MyViews/test.cshtml");
        }
    }
}
