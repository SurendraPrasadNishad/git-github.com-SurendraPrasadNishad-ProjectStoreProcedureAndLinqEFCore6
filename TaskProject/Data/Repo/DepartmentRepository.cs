using Microsoft.EntityFrameworkCore;
using TaskProject.Data.InterfaceRepo;
using TaskProject.Models;

namespace TaskProject.Data.Repo
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly CompanyContext _context;
        public DepartmentRepository(CompanyContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var deptData = await _context.Departments.ToListAsync();
            return deptData;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var deptData = await _context.Departments.FindAsync(id);
            return deptData;
        }

        public async Task<bool> AddDepartmentAsync(Department model)
        {
            var data = await _context.Departments.Where(x => x.DepartmentName == model.DepartmentName).FirstOrDefaultAsync();
            if (data == null)
            {               
                    await _context.Departments.AddAsync(model);
                    _context.SaveChanges();
                    return true;             
            }
            return false;
        }

        public async Task<bool> UpdateDepartmentAsync(int id, Department department)
        {
            var deptData=new Department()
            { 
            DepartmentId= id,
            DepartmentName=department.DepartmentName
            };
            _context.Departments.Update(deptData);
             await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var data = await _context.Departments.FindAsync(id);
            if (data != null)
            {
                _context.Departments.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
