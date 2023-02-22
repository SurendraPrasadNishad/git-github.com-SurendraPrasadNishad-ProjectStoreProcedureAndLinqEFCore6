using Microsoft.EntityFrameworkCore;
using System.Collections;
using TaskProject.Data.InterfaceRepo;
using TaskProject.Models;


namespace TaskProject.Data.Repo
{
    public class EmployeeRepository:IEmployeeRepository
    {

        private readonly CompanyContext _context;

        public EmployeeRepository(CompanyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var empData = await _context.Employees.FromSqlInterpolated($"exec spGetAllEmployees").ToListAsync();          
            var deptData = await _context.Departments.FromSqlInterpolated($"exec spGetAllDepartments").ToListAsync();
            return empData;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentListsAsync()
        {
            var deptData = await _context.Departments.FromSqlInterpolated($"exec spGetAllDepartments").ToListAsync();
            return deptData;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int EmployeeId)
        {
            var empData = await _context.Employees.FromSqlInterpolated($"exec spGetEmployeeById @EmployeeId={EmployeeId}").ToListAsync();
            var data=empData.FirstOrDefault();
            var deptData = await _context.Departments.FromSqlInterpolated($"exec spGetDepartmentById @DepartmentId={data.DepartmentId}").ToListAsync();        
            return data;
        }

        public async Task<bool> AddEmployeeAsync(Employee model)
        {

            var empData = await _context.Database.ExecuteSqlInterpolatedAsync($"exec spCreateEmployee @EmployeeName={model.EmployeeName},@EmployeeAddress={model.EmployeeAddress},@DepartmentId={model.DepartmentId}");
            if (empData > 0)
            {
                return true;
            }
            return false;


        }

        public async Task<bool> UpdateEmployeeAsync(int EmployeeId, Employee model)
        {
            var empData = await _context.Employees.FromSqlInterpolated($"exec spGetEmployeeById @EmployeeId={EmployeeId}").ToListAsync();
            var employeeData = empData.FirstOrDefault();
            if (employeeData != null)
            {
                var rowaffect = await _context.Database.ExecuteSqlInterpolatedAsync($"exec spUpdateEmployee @EmployeeId={EmployeeId},@EmployeeName={model.EmployeeName},@EmployeeAddress={model.EmployeeAddress},@DepartmentId={model.DepartmentId}");
                if (rowaffect > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteEmployeeAsync(int EmployeeId)
        {           
                var rowaffect = await _context.Database.ExecuteSqlInterpolatedAsync($"exec spDeleteEmployee @EmployeeId={EmployeeId}");
                if (rowaffect > 0)
                {
                    return true;
                }
                return false;
        }
    }
}
