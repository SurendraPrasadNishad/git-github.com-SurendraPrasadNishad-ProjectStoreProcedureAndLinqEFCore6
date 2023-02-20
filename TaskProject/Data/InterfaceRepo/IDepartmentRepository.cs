using TaskProject.Models;

namespace TaskProject.Data.InterfaceRepo
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<bool> AddDepartmentAsync(Department model);
        Task<bool> UpdateDepartmentAsync(int id, Department model);
        Task<bool> DeleteDepartmentAsync(int id);

    }
}
