using EmployeeManagementCRUDOperation.Models;
using EmployeeManagementCRUDOperation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EmployeeManagementCRUDOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                //_employeeService.GetDepartmentList();
                var a = await _employeeService.GetEmployeeList();
                return View(a);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public IActionResult CreateEmployee()
        {
            try
            {
                return PartialView("_CreateEmployeePartial");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _employeeService.AddEmployee(employee);
                    if (result > 0)
                    {
                        TempData["Message"] = "Data Inserted Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Data Inserted Failed";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> GetEmployeeDetails(int Id)
        {
            try
            {
                var empData = await _employeeService.GetEmployeeDetailsById(Id);
                return PartialView("_GetEmployeeDetailsPartial", empData);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);
                if (result > 0)
                {
                    TempData["Message"] = "Data Deleted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Data Deleted Failed";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> getEmpById_ForEdit(int Id)
        {
            try
            {
                var empData = await _employeeService.GetEmployeeDetailsById(Id);
                return PartialView("_getEmpById_ForEditPartial", empData);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> getEmpById_ForEdit(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _employeeService.UpdateEmployee(employee);
                    if (result > 0)
                    {
                        TempData["Message"] = "Data Updated Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Data Updated Failed";
                    }
                }
                return PartialView("_getEmpById_ForEditPartial");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
