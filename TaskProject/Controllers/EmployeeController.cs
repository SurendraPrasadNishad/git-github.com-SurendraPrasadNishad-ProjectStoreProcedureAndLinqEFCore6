using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskProject.Data.InterfaceRepo;
using TaskProject.Models;

namespace TaskProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeesRepo;
       

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeesRepo = employeeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _employeesRepo.GetAllEmployeesAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) 
            {
                return View("NotFound");
            }
            var data = await _employeesRepo.GetEmployeeByIdAsync(id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var formDropdownDataList = await _employeesRepo.GetAllDepartmentListsAsync();
            ViewBag.departmentList = new SelectList(formDropdownDataList, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("EmployeeName,EmployeeAddress,DepartmentId")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var formDropdownDataList = await _employeesRepo.GetAllDepartmentListsAsync();
                ViewBag.departmentList = new SelectList(formDropdownDataList, "DepartmentId", "DepartmentName");
                return View(employee);
            }
            else
            await _employeesRepo.AddEmployeeAsync(employee);
            ModelState.Clear();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var formDropdownDataList = await _employeesRepo.GetAllDepartmentListsAsync();
            ViewBag.departmentList = new SelectList(formDropdownDataList, "DepartmentId", "DepartmentName");
            var empDetails = await _employeesRepo.GetEmployeeByIdAsync(id);
            if (empDetails == null)
                return View("NotFound");
            else
                return View(empDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeName,EmployeeAddress,DepartmentId")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                var empCheck = await _employeesRepo.UpdateEmployeeAsync(id ,employee);
                if (empCheck == true)
                {
                    ViewBag.Data = "Data is inserted, Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Data = "Sorry,Data is Not inserted!";
                return RedirectToAction(nameof(Index));

            }
        }
        //Get: Delete Confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var empDetails = await _employeesRepo.GetEmployeeByIdAsync(id);
            if (empDetails == null)
                return View("NotFound");
            else
                return View(empDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empDetails = await _employeesRepo.GetEmployeeByIdAsync(id);
            if (empDetails == null)
            {
                return View("NotFound");
            }
            else
            {
               var data =await _employeesRepo.DeleteEmployeeAsync(id);
                if (data == true)
                {
                    ViewBag.Message = "Delete Success!";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = "Delete Not Succeed!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
