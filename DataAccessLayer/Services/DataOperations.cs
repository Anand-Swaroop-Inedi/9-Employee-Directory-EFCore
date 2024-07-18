using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data;
namespace DataAccessLayer.Services
{
    public class DataOperations : DbContext, IDataOperations
    {
        private static String ConnectionString = "data source=SQL-DEV; database=ConsoleDBEF; integrated security=SSPI; ENCRYPT=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<Employee> EmployeesDb { get; set; }
        public DbSet<Roles> RolesDb { get; set; }
        public DbSet<Department> DepartmentDb { get; set; }
        public DbSet<Project> ProjectDb { get; set; }
        public DbSet<Location> LocationDb { get; set; }


        public async Task<bool> AddEmployeeToDb(Employee employee)
        {
            if (RolesDb.Where(r => r.Name == employee.JobTitle).Count() == 0)
            {
                Roles roles = new Roles();
                roles.Name = employee.JobTitle;
                roles.Department = employee.Department;
                roles.Location = employee.Location;
                AddRoleToDb(roles);
            }
            if(ProjectDb.Where(p=>p.Name==employee.Project).Count()== 0)
            {
                Project project = new Project();
                project.Name = employee.Project;
                ProjectDb.Add(project);
            }
            EmployeesDb.Add(employee);
            SaveChanges();
            return true;
        }
        public async Task<bool> AddDepartmentToDb(Department department)
        {
            DepartmentDb.Add(department);
            SaveChanges();
            return true;
        }
        public async Task<bool> AddProjectToDb(Project project)
        {
            ProjectDb.Add(project);
            SaveChanges();
            return true;
        }
        public async Task<bool> AddLocationToDb(Location location)
        {
            LocationDb.Add(location);
            SaveChanges();
            return true;
        }
        public async Task<bool> AddRoleToDb(Roles role)
        {
            if (DepartmentDb.Where(d => d.Name == role.Department).Count() == 0)
            {
                Department department = new Department();
                department.Name = role.Name;
                DepartmentDb.Add(department);
            }
            if (LocationDb.Where(l => l.Name == role.Location).Count() == 0)
            {
                Location location = new Location();
                location.Name = role.Location;
                LocationDb.Add(location);
            }
            RolesDb.Add(role);
            SaveChanges();
            return true;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return (from employee in EmployeesDb select employee).ToList();
        }
        public async Task<Employee> GetEmployeeById(string Id)
        {
            return (from employee in EmployeesDb where employee.Id == Id select employee).ToList()[0];
        }
        public async Task<List<Roles>> GetRoles()
        {
            return (from role in RolesDb select role).ToList();
        }
        public async Task<List<Location>> GetLocations()
        {
            return (from location in LocationDb select location).ToList();
        }
        public async Task<List<Project>> GetProjects()
        {
            return (from project in ProjectDb select project).ToList();
        }
        public async Task<List<Department>> GetDepartments()
        {
            return (from department in DepartmentDb select department).ToList();
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            return false;
        }
        public async Task<bool> DeleteEmployee(string id)
        {
            EmployeesDb.Remove((from emp in EmployeesDb where emp.Id == id select emp).FirstOrDefault());
            SaveChanges();
            return true;
        }
    }
}


