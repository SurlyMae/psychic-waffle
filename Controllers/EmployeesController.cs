using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESTfulAPI.AspNetCore.NewDb.Models;
using RESTfulAPI.AspNetCore.NewDb.Services;
using AutoMapper;

namespace RESTfulAPI.AspNetCore.NewDb.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly PersonnelContext _context;
        private IPersonnelRepo _repo;

        // public EmployeesController(PersonnelContext context)
        // {
        //     _context = context;
        // }

        public EmployeesController (IPersonnelRepo repository)
        {
            _repo = repository;
        }

        [HttpGet("api/employees")]
        public IActionResult GetEmployees()
        {
            var empsFromRepo = _repo.GetEmployees();
            var emps = Mapper.Map<IEnumerable<EmployeeDTO>>(empsFromRepo);
            return Ok(emps);
        }

        [HttpGet("api/employees/{id}")]
        public IActionResult GetEmployee (int id)
        {
            var empFromRepo = _repo.GetEmployee(id);

            if (empFromRepo == null)
            {
                return NotFound();
            }
            
            var emp = Mapper.Map<EmployeeDTO>(empFromRepo);
            return Ok(emp);
        }

        // // GET: Employees
        // public async Task<IActionResult> Index()
        // {
        //     var personnelContext = _context.Employees.Include(e => e.Department);
        //     return View(await personnelContext.ToListAsync());
        // }

        // // GET: Employees/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var employee = await _context.Employees
        //         .Include(e => e.Department)
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(employee);
        // }

        // // GET: Employees/Create
        // public IActionResult Create()
        // {
        //     ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
        //     return View();
        // }

        // // POST: Employees/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Type,FirstName,LastName,DepartmentId")] Employee employee)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(employee);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
        //     return View(employee);
        // }

        // // GET: Employees/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var employee = await _context.Employees.FindAsync(id);
        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
        //     return View(employee);
        // }

        // // POST: Employees/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Type,FirstName,LastName,DepartmentId")] Employee employee)
        // {
        //     if (id != employee.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(employee);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!EmployeeExists(employee.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
        //     return View(employee);
        // }

        // // GET: Employees/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var employee = await _context.Employees
        //         .Include(e => e.Department)
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(employee);
        // }

        // // POST: Employees/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var employee = await _context.Employees.FindAsync(id);
        //     _context.Employees.Remove(employee);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool EmployeeExists(int id)
        // {
        //     return _context.Employees.Any(e => e.Id == id);
        // }
    }
}
