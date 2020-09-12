using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTesting.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private  List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Sam",Department="IT",Email="sam@yu.com" },
                new Employee(){Id=2,Name="Ram",Department="HR",Email="ram@yu.com" },
                new Employee(){Id=3,Name="Wam",Department="CS",Email="wam@yu.com" },
                new Employee(){Id=4,Name="Bam",Department="PO",Email="bam@yu.com" },
                new Employee(){Id=5,Name="Dam",Department="GS",Email="dam@yu.com" }

            };
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
