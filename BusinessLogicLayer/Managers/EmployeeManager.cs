using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using Models;


namespace BusinessLogicLayer.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IDataOperations _dataOperations;
        public EmployeeManager( IDataOperations dataOperations)
        {
            _dataOperations = dataOperations;
        }
        public async Task<bool> Create(Employee employee)
        {
            if (await _dataOperations.AddEmployeeToDb(employee))
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Update(Employee employee)
        {
            if (await _dataOperations.UpdateEmployee(employee))
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string id)
        {
            int index = await CheckIdExists(id);
            if (index == -1)
            {
                return false;
            }
            else
            {
                if(await _dataOperations.DeleteEmployee(id))
                {
                    return true;
                }
                return false;  
            }
        }
        public async Task<int> CheckIdExists(string id)
        {
            List<Employee> employeeList = await GetAll();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _dataOperations.GetEmployees();
        }
        public async Task<Employee> GetSingleEmployee(string  id)
        {
            return await _dataOperations.GetEmployeeById(id);
        }
    }

}
