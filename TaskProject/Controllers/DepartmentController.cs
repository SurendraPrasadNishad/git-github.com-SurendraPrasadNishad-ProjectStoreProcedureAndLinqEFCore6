using Microsoft.AspNetCore.Mvc;
using TaskProject.Data.InterfaceRepo;
using TaskProject.Models;

namespace TaskProject.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepo = departmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _departmentRepo.GetAllDepartmentsAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View("NotFound");
            }
            var data = await _departmentRepo.GetDepartmentByIdAsync(id);
            return View(data);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("DepartmentName")] Department department)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Data is not inserted ,Sorry!";

                return View(department);
            }
            else
               await _departmentRepo.AddDepartmentAsync(department);
            ModelState.Clear();
            ViewBag.Message = "Data is inserted ,Successfully!";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var deptDetails = await _departmentRepo.GetDepartmentByIdAsync(id);
            if (deptDetails == null)
                return View("NotFound");
            else
                return View(deptDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentName")] Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            else
            {
                var deptCheck = await _departmentRepo.UpdateDepartmentAsync(id, department);
                if (deptCheck == true)
                {
                    ViewBag.Message = "Data is updated, Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = "Sorry,Data is Not updated!";
                return RedirectToAction(nameof(Index));

            }
        }
        //Get: Delete Confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var deptDetails = await _departmentRepo.GetDepartmentByIdAsync(id);
            if (deptDetails == null)
                return View("NotFound");
            else
                return View(deptDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var deptDetails = await _departmentRepo.GetDepartmentByIdAsync(id);
            if (deptDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                var data = await _departmentRepo.DeleteDepartmentAsync(id);
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
