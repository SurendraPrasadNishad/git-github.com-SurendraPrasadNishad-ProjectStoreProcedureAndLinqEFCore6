using TaskProject.Models;
using TaskProject.ViewModels;

namespace TaskProject.Data.InterfaceRepo
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentListsAsync();
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<bool> AddEmployeeAsync(Employee model);
        Task<bool> UpdateEmployeeAsync(int id, Employee model);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
