namespace Presentation.Interfaces
{
    public interface IEmployeeManagement
    {
        public Task AddEmployee();
        public Task DisplayAll();
        public Task DisplayOne();
        public Task UpdateEmployee();
        public Task DeleteEmployee();
    }
}
