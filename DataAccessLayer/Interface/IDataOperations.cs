using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDataOperations
    {
        public  Task<bool> AddEmployeeToDb(Employee emp);
        public Task<bool> AddRoleToDb(Roles role);
        public Task<bool> AddLocationToDb(Location location);
        public Task<bool> AddProjectToDb(Project project);
        public Task<bool> AddDepartmentToDb(Department department);
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(string id);
        public Task<List<Roles>> GetRoles();
        public Task<List<Location>> GetLocations();
        public Task<List<Project>> GetProjects();
        public Task<List<Department>> GetDepartments();
        public Task<bool> DeleteEmployee(string id);
        public Task<bool> UpdateEmployee(Employee employee);
/*        public Task<List<T>> Read<T>(string filePath);
        public Task<bool> Write<T>(List<T> t, string filePath);*/

    }
}
