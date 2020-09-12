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
    }
}
