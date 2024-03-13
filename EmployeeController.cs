using Microsoft.AspNetCore.Mvc;
using MVC_CORE_tu.Data;
using MVC_CORE_tu.Migrations;
using MVC_CORE_tu.Models;

namespace MVC_CORE_tu.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplictionDbContext _context;

        public EmployeeController(ApplictionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Employees.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var Emp = new Employee()
                {
                    Name = emp.Name,
                    Gender = emp.Gender,
                    Email = emp.Email,
                    Country = emp.Country,
                };
                _context.Employees.Add(Emp);
                _context.SaveChanges();
                TempData["Error"] = "Record saved!!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Empty field Can't submit";
                return View(emp);
            }

        }
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.SingleOrDefault(x => x.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                Gender = emp.Gender,
                Email = emp.Email,
                Country = emp.Country,
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var result = new Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                Gender = emp.Gender,
                Email = emp.Email,
                Country = emp.Country,
            };
            _context.Employees.Update(result);
            _context.SaveChanges();
            TempData["Error"] = "Record Updated!!";
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var data = _context.Employees.SingleOrDefault(x => x.Id == id);
            _context.Employees.Remove(data);
            _context.SaveChanges();
            TempData["Error"] = "Record Deleted!!";
            return RedirectToAction("Index");
        }
    }
}
