using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RESTfulAPI.AspNetCore.NewDb.Models
{
    public class PersonnelContext : DbContext 
    {
        public PersonnelContext(DbContextOptions<PersonnelContext> options) : base(options) => Database.Migrate();

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    public static class Helpers 
    {
        public static void SeedDatabase(this PersonnelContext context)
        {
            //clear db
            context.Departments.RemoveRange(context.Departments);
            context.SaveChanges();

            //seed db
            var depts = new List<Department>()
            {
                new Department()
                {
                    DepartmentId = 100,
                    Name = "Human Resources",
                    Employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Id = 101,
                            Type = "Staff",
                            FirstName = "Marnie",
                            LastName = "Williams",
                            DepartmentId = 100
                        },
                        new Employee()
                        {
                            Id = 102,
                            Type = "Staff",
                            FirstName = "Nicole",
                            LastName = "Smith",
                            DepartmentId = 100
                        }
                    }
                },
                new Department()
                {
                    DepartmentId = 200,
                    Name = "Information Services",
                    Employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Id = 201,
                            Type = "Staff",
                            FirstName = "Andrea",
                            LastName = "Sevy",
                            DepartmentId = 200
                        },
                        new Employee()
                        {
                            Id = 202,
                            Type = "Staff",
                            FirstName = "Leigh",
                            LastName = "Ward",
                            DepartmentId = 200
                        }
                    }
                },
                new Department()
                {
                    DepartmentId = 300,
                    Name = "School of Business",
                    Employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Id = 301,
                            Type = "Staff",
                            FirstName = "Lindsay",
                            LastName = "Farmer",
                            DepartmentId = 300
                        },
                        new Employee()
                        {
                            Id = 302,
                            Type = "Faculty",
                            FirstName = "Ellena",
                            LastName = "Barker",
                            DepartmentId = 300
                        }
                    }
                }
            };
            context.Departments.AddRange(depts);
            context.SaveChanges();
        }
    }
}