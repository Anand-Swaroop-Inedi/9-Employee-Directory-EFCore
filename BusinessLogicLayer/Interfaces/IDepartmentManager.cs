using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartmentManager
    {
        public Task<bool> AddDepartment(Department dept);
        public Task<List<Department>> GetAll();
        public Task<string> GetDepartmentName(int id);
    }
}
