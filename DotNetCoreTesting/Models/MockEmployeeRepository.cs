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
                new Employee(){Id=1,Name="Sam",Department=Dept.IT,Email="sam@yu.com" },
                new Employee(){Id=2,Name="Ram",Department=Dept.HR,Email="ram@yu.com" },
                new Employee(){Id=3,Name="Wam",Department=Dept.Finance,Email="wam@yu.com" },
                new Employee(){Id=4,Name="Bam",Department=Dept.Admin,Email="bam@yu.com" },
                new Employee(){Id=5,Name="Dam",Department=Dept.CS,Email="dam@yu.com" }

            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee!=null)
            {
                _employeeList.Remove(employee);
            }

            return employee;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }

            return employee;

        }
    }
}
