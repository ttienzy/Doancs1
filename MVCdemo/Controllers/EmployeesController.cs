using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCdemo.Data;
using MVCdemo.Models;
using NuGet.Protocol;

namespace MVCdemo.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly HumanResourceManagementContext _context;
        public readonly IWebHostEnvironment _environment;

        public EmployeesController(HumanResourceManagementContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set is null.");
            }

            var movies = from m in _context.Employees
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.EmployeeName!.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> SalaryDetails()
        {
            var salaryDetails = from emp in _context.Employees
                                join sal in _context.Salarys on emp.LevelSalary equals sal.LevelSalary
                                join dep in _context.Departments on emp.DepartmentID equals dep.DepartmentID
                                join pos in _context.Positions on emp.PositionID equals pos.PositionId
                                select new
                                {
                                    Name = emp.EmployeeName,
                                    Email = emp.Email,
                                    Position = pos.PositionName,
                                    Department = $"{dep.DepartmentName}-{dep.DepartmentAddress}",
                                    SalaryEmployee = sal.BasicSalary,
                                    Coefficient = sal.CoefficientsSalary,
                                };
            ViewBag.Details = await salaryDetails.SumAsync(s => s.SalaryEmployee * s.Coefficient);
            ViewBag.NumberEmp = await salaryDetails.Select(s => s.Name).CountAsync();
            return View(await salaryDetails.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Khu_D()
        {

            var salaryDetails = from emp in _context.Employees
                                join sal in _context.Salarys on emp.LevelSalary equals sal.LevelSalary
                                join dep in _context.Departments on emp.DepartmentID equals dep.DepartmentID
                                join pos in _context.Positions on emp.PositionID equals pos.PositionId
                                where dep.DepartmentName == "Khu D"
                                select new
                                {
                                    Name = emp.EmployeeName,
                                    Email = emp.Email,
                                    Position = pos.PositionName,
                                    Department = $"{dep.DepartmentName}-{dep.DepartmentAddress}",
                                    SalaryEmployee = sal.BasicSalary,
                                };
            ViewBag.Khu_D = await salaryDetails.SumAsync(s => s.SalaryEmployee);
            ViewBag.NumberEmpKhu_D = await salaryDetails.Select(s => s.Name).CountAsync();
            return View(await salaryDetails.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Khu_A()
        {

            var salaryDetails = from emp in _context.Employees
                                join sal in _context.Salarys on emp.LevelSalary equals sal.LevelSalary
                                join dep in _context.Departments on emp.DepartmentID equals dep.DepartmentID
                                join pos in _context.Positions on emp.PositionID equals pos.PositionId
                                where dep.DepartmentName == "Khu A"
                                select new
                                {
                                    Name = emp.EmployeeName,
                                    Email = emp.Email,
                                    Position = pos.PositionName,
                                    Department = $"{dep.DepartmentName}-{dep.DepartmentAddress}",
                                    SalaryEmployee = sal.BasicSalary,
                                };
            ViewBag.Khu_A = await salaryDetails.SumAsync(s => s.SalaryEmployee);
            ViewBag.NumberEmpKhu_A = await salaryDetails.Select(s => s.Name).CountAsync();
            return View(await salaryDetails.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Khu_B()
        {

            var salaryDetails = from emp in _context.Employees
                                join sal in _context.Salarys on emp.LevelSalary equals sal.LevelSalary
                                join dep in _context.Departments on emp.DepartmentID equals dep.DepartmentID
                                join pos in _context.Positions on emp.PositionID equals pos.PositionId
                                where dep.DepartmentName == "Khu B"
                                select new
                                {
                                    Name = emp.EmployeeName,
                                    Email = emp.Email,
                                    Position = pos.PositionName,
                                    Department = $"{dep.DepartmentName}-{dep.DepartmentAddress}",
                                    SalaryEmployee = sal.BasicSalary,
                                };
            ViewBag.Khu_B = await salaryDetails.SumAsync(s => s.SalaryEmployee);
            ViewBag.NumberEmpKhu_B = await salaryDetails.Select(s => s.Name).CountAsync();
            return View(await salaryDetails.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Khu_C()
        {

            var salaryDetails = from emp in _context.Employees
                                join sal in _context.Salarys on emp.LevelSalary equals sal.LevelSalary
                                join dep in _context.Departments on emp.DepartmentID equals dep.DepartmentID
                                join pos in _context.Positions on emp.PositionID equals pos.PositionId
                                where dep.DepartmentName == "Khu C"
                                select new
                                {
                                    Name = emp.EmployeeName,
                                    Email = emp.Email,
                                    Position = pos.PositionName,
                                    Department = $"{dep.DepartmentName}-{dep.DepartmentAddress}",
                                    SalaryEmployee = sal.BasicSalary,
                                };
            ViewBag.Khu_C = await salaryDetails.SumAsync(s => s.SalaryEmployee);
            ViewBag.NumberEmpKhu_C = await salaryDetails.Select(s => s.Name).CountAsync();
            return View(await salaryDetails.ToListAsync());
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var humanResourceManagementContext = _context.Employees.Include(e => e.department).Include(e => e.position).Include(e => e.salary);

            return View(await humanResourceManagementContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.department)
                .Include(e => e.position)
                .Include(e => e.salary)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentAddress");
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            ViewData["LevelSalary"] = new SelectList(_context.Salarys, "LevelSalary", "BasicSalary");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeeEthnic,EmployeeGender,nativeland,EmployeePhone,Email,PositionID,LevelSalary,DepartmentID,formFile")] Employee employee)
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentAddress", employee.DepartmentID);
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionId", "PositionName", employee.PositionID);

            //ViewData["LevelSalary"] = new SelectList(_context.Salarys, "LevelSalary", "BasicSalary", employee.LevelSalary);
            foreach (var salarys in _context.Salarys)
            {
                if (salarys.LevelSalary == employee.PositionID)
                {
                    employee.LevelSalary = employee.PositionID;
                    break;
                }
                else
                {
                    employee.LevelSalary = 1;
                }
            }

            string wwwrootPath = _environment.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(employee.formFile.FileName);
            string extension = Path.GetExtension(employee.formFile.FileName);
            filename = filename + DateTime.Now.ToString("hh-mm-ss") + extension;
            employee.UrlImage = filename;
            string path = Path.Combine(wwwrootPath + "/Image", filename);  //wwwroot/Image/...

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await employee.formFile.CopyToAsync(fileStream);
            }


            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            /*var emp = new Employee();
            emp.EmployeeId = id.Value;
            emp.EmployeeName = employee.EmployeeName;
            emp.UrlImage = employee.UrlImage;
            emp.EmployeeEthnic = employee.EmployeeEthnic;
            emp.Email = employee.Email;
            emp.EmployeeGender = employee.EmployeeGender;
            emp.nativeland = employee.nativeland;
            emp.EmployeePhone = employee.EmployeePhone;
            emp.PositionID = employee.PositionID;
            emp.DepartmentID = employee.DepartmentID;
            emp.LevelSalary = employee.LevelSalary;*/


            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentAddress", employee.DepartmentID);
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionId", "PositionName", employee.PositionID);
            ViewData["LevelSalary"] = new SelectList(_context.Salarys, "LevelSalary", "BasicSalary", employee.LevelSalary);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,EmployeeEthnic,EmployeeGender,nativeland,EmployeePhone,Email,PositionID,LevelSalary,DepartmentID,formFile")] Employee employee)
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentAddress", employee.DepartmentID);
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionId", "PositionName", employee.PositionID);
            ViewData["LevelSalary"] = new SelectList(_context.Salarys, "LevelSalary", "BasicSalary", employee.LevelSalary);


            try
            {
                string wwwrootPath = _environment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(employee.formFile.FileName);
                string extension = Path.GetExtension(employee.formFile.FileName);
                filename = filename + DateTime.Now.ToString("hh-mm-ss") + extension;
                employee.UrlImage = filename;
                string path = Path.Combine(wwwrootPath + "/Image", filename);  //wwwroot/Image/...

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await employee.formFile.CopyToAsync(fileStream);
                }

                var emp = await _context.Employees.FindAsync(id);
                emp.EmployeeName = employee.EmployeeName;
                emp.UrlImage = employee.UrlImage;
                emp.EmployeeEthnic = employee.EmployeeEthnic;
                emp.Email = employee.Email;
                emp.EmployeeGender = employee.EmployeeGender;
                emp.nativeland = employee.nativeland;
                emp.EmployeePhone = employee.EmployeePhone;
                emp.PositionID = employee.PositionID;
                emp.DepartmentID = employee.DepartmentID;
                emp.LevelSalary = employee.LevelSalary;




                _context.Update(emp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.department)
                .Include(e => e.position)
                .Include(e => e.salary)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }


    }
}
