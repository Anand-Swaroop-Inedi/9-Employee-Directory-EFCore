using Models;
namespace Presentation.Interfaces
{
    public interface IEmployeePropertyEntryManager
    {
        public void DisplayHeaders();
        public string GetFirstName();
        public string GetLastName();
        public string GetEmail();
        public string GetDateOfBirth();
        public string GetMobileNo();
        public string GetJoiningDate();
        public Task<string> ChooseProject();
        public Task<string> ChooseRole();
        public Task<string> ChooseDepartment(Employee employee);
        public Task<string> ChooseLocation(Employee employee);
        public string ChooseManager(Employee employeeModel, List<Employee> employeeList);
    }
}
