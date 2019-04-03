using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RESTfulAPI.AspNetCore.NewDb.Models
{
    public class Department 
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}