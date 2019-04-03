using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RESTfulAPI.AspNetCore.NewDb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}