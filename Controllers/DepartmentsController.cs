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
    public class DepartmentsController : Controller
    {
        //private PersonnelContext _context;
        private IPersonnelRepo _repo;

        // public DepartmentsController (PersonnelContext context)
        // {
        //     _context = context;
        // }

        public DepartmentsController (IPersonnelRepo repository)
        {
            _repo = repository;
        }
        [HttpGet("api/departments")]
        public IActionResult GetDepartments ()
        {
            var deptsFromRepo = _repo.GetDepartments();
            var depts = Mapper.Map<IEnumerable<DepartmentDTO>>(deptsFromRepo);
            return Ok(depts);
        }

        [HttpGet("api/departments/{id}", Name = "GetDept")]
        public IActionResult GetDepartment (int id)
        {
            var deptFromRepo = _repo.GetDepartment(id);

            if (deptFromRepo == null)
            {
                return NotFound();
            }

            var dept = Mapper.Map<DepartmentDTO>(deptFromRepo);
            return Ok(dept);
        }

        [HttpPost("api/departments")]
        public IActionResult CreateDeparment ([FromBody] DepartmentForCreationDTO dept)
        {
            if (dept == null)
            {
                return BadRequest();
            }

            var deptToCreate = Mapper.Map<Department>(dept);
            _repo.AddDepartment(deptToCreate);
            
            if (!_repo.Save())
            {
                //costly but we already implemented global exception handling so...
                throw new Exception("Creating a department failed on save.");
            }

            var deptCreated = Mapper.Map<DepartmentDTO>(deptToCreate);
            //return 201 created response with location header containing URI of newly created dept
            return CreatedAtRoute("GetDept", new { id = deptCreated.DepartmentId}, deptToCreate );
        }

        // //GET: Departments
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Departments.ToListAsync());
        // }

        // //GET: Departments/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var department = await _context.Departments
        //         .FirstOrDefaultAsync(m => m.DepartmentId == id);
        //     if (department == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(department);
        // }

        // // GET: Departments/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: Departments/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("DepartmentId,Name")] Department department)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(department);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(department);
        // }

        // //GET: Departments/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var department = await _context.Departments.FindAsync(id);
        //     if (department == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(department);
        // }

        // // POST: Departments/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,Name")] Department department)
        // {
        //     if (id != department.DepartmentId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(department);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!DepartmentExists(department.DepartmentId))
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
        //     return View(department);
        // }

        // // GET: Departments/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var department = await _context.Departments
        //         .FirstOrDefaultAsync(m => m.DepartmentId == id);
        //     if (department == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(department);
        // }

        // // POST: Departments/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var department = await _context.Departments.FindAsync(id);
        //     _context.Departments.Remove(department);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool DepartmentExists(int id)
        // {
        //     return _context.Departments.Any(e => e.DepartmentId == id);
        // }
    }
}
