using RESTfulAPI.AspNetCore.NewDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulAPI.AspNetCore.NewDb.Services
{
    public class PersonnelRepo : IPersonnelRepo
    {
        private PersonnelContext _db;

        public PersonnelRepo(PersonnelContext context) => _db = context;

        public IEnumerable<Department> GetDepartments() => _db.Departments.OrderBy(d => d.Name);

        public IEnumerable<Department> GetDepartments(IEnumerable<int> ids) => _db.Departments.Where(d => ids.Contains(d.DepartmentId)).OrderBy(d => d.Name).ToList();

        public Department GetDepartment(int id) => _db.Departments.FirstOrDefault(d => d.DepartmentId == id);

        public bool DepartmentExists(int id) => _db.Departments.Any(d => d.DepartmentId == id);

        public IEnumerable<Employee> GetEmployeesByType(string empType) => _db.Employees.Where(e => e.Type == empType).OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();

        public IEnumerable<Employee> GetEmployeesByDept(int id) => _db.Employees.Where(e => e.DepartmentId == id).OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();

        public Employee GetEmployee(int empId) => _db.Employees.Where(e => e.Id == empId).FirstOrDefault();
    }
}