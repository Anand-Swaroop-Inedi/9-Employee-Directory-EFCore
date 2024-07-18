using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeManager
    {
        public Task<bool> Create(Employee employee);
        public Task<bool> Update(Employee employee);
        public Task<bool> Delete(string id);
        public Task<int> CheckIdExists(string id);
        public Task<Employee> GetSingleEmployee(string id);

        public Task<List<Employee>> GetAll();
    }
}
