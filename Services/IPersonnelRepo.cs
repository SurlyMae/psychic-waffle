using RESTfulAPI.AspNetCore.NewDb.Models;
using System.Collections.Generic;

namespace RESTfulAPI.AspNetCore.NewDb.Services
{
    public interface IPersonnelRepo
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartments(IEnumerable<int> deptIds);
        Department GetDepartment(int deptId);
        bool DepartmentExists(int deptId);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployeesByType(string empType);
        IEnumerable<Employee> GetEmployeesByDept(int deptId);
        Employee GetEmployeeByDept(int deptId, int empId);
        Employee GetEmployee(int empId);
        void AddDepartment(Department dept);
        void AddEmployeeToDepartment(int deptId, Employee emp);
        void UpdateEmployee(Employee emp);
        bool Save();
    }
}