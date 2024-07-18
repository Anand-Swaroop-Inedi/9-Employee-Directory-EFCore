using BusinessLogicLayer.Interfaces;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public class DisplayMenuManagement : IDisplayMenuManagement
    {
        private readonly IEmployeeManagement _employeeManagement;
        private readonly ILocationManagement _locationManagement;
        private readonly IDepartmentManagement _departmentManagement;
        private readonly IRoleManagement _roleManagement;
        private readonly IEmployeeManager _employeeManager;
        private readonly IProjectManagement _projectManagement;
        private static List<String> _startAppDisplayMenu = new List<String>() { "Exit", "Employee Management", "Role Management", "Department and Location Management" };
        private static List<String> _employeeDisplayMenu = new List<string>() { "Go Back", "Add Employee", "Display All", "Display One", "Edit Employee", "Delete Employee" };
        private static List<String> _roleDisplaymenu = new List<string>() { "Go Back", "Add Role", "Display All" };
        public static List<String> _departmentLocationDisplaymenu = new List<String>() { "Go Back", "Add Department", "Display Departments", "Add Location", "Display Locations", "Add Project", "Display Projects" };
        public DisplayMenuManagement(IEmployeeManagement employeeManagement, ILocationManagement locationManagement, IDepartmentManagement departmentManagement, IRoleManagement roleManagement, IEmployeeManager employeeManager, IProjectManagement projectManagement)
        {
            _employeeManagement = employeeManagement;
            _departmentManagement = departmentManagement;
            _locationManagement = locationManagement;
            _roleManagement = roleManagement;
            _employeeManager = employeeManager;
            _projectManagement = projectManagement;
        }
        private async static Task DisplayMenus(List<string> menu)
        {

            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i}. {menu[i]}");
            }
        }
        public async Task StartAppDisplayOptionMenu()
        {
            Console.WriteLine("Welcome to Employee Directory Console App");
            bool flag = true;
            while (flag)
            {
                await DisplayMenus(_startAppDisplayMenu);
                Console.Write("Choose any option from above:");
                int option;
                string input = Console.ReadLine();
                int.TryParse(input, out option);
                if (option == 0 && input != "0")
                {
                    Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                    StartAppDisplayOptionMenu();
                    return;
                }
                switch (option)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        await this.EmployeeManagementDisplayMenu();
                        break;
                    case 2:
                        await this.RoleManagementDisplayMenu();
                        break;
                    case 3:
                        await this.DepartmentLocationDisplayMenu();
                        break;

                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
            Console.WriteLine("Thank You for visiting our application");
        }
        private async Task<bool> EmployeeDisplayDefaultMenu()
        {
            bool flag = true;
            Console.WriteLine("Options :");
            Console.WriteLine("0. Go Back");
            Console.WriteLine("1. Add Employee");
            Console.Write("Choose any1 option from above:");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            if (option == 0 && input != "0")
            {
                Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                return await EmployeeDisplayDefaultMenu();
            }
            switch (option)
            {
                case 0:
                    flag = false;
                    break;
                case 1:
                    await _employeeManagement.AddEmployee();
                    break;

                default:
                    Console.WriteLine("Select option from the above list only");
                    break;
            }
            return flag;
        }
        //Displaying Menu When Employee Json has more than 1 employee count

        private async Task<bool> EmployeeDisplayAdjustedMenu()
        {
            bool flag = true;

            Console.WriteLine("Options :");
            await DisplayMenus(_employeeDisplayMenu);
            Console.Write("Choose any option from above:");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            if (option == 0 && input != "0")
            {
                Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                return await EmployeeDisplayAdjustedMenu();
            }
            switch (option)
            {
                case 0:
                    flag = false;
                    break;
                case 1:
                   await _employeeManagement.AddEmployee();
                    break;
                case 2:
                    await  _employeeManagement.DisplayAll();
                    break;
                case 3:
                    await _employeeManagement.DisplayOne();
                    break;
                case 4:
                    await  _employeeManagement.UpdateEmployee();
                    break;
                case 5:
                    await  _employeeManagement.DeleteEmployee();
                    break;
                default:
                    Console.WriteLine("Select option from the above list only\n");
                    break;
            }
            return flag;
        }
        //To Display Menu
        private async Task EmployeeManagementDisplayMenu()
        {

            bool flag = true;
            while (flag)
            {
                List<Employee> employeeList = await _employeeManager.GetAll();
                if (employeeList.Count < 1)
                {
                    flag = await EmployeeDisplayDefaultMenu();
                }

                else
                {
                    flag = await EmployeeDisplayAdjustedMenu();
                }
            }
        }
        private async Task RoleManagementDisplayMenu()
        {
            bool flag = true;
            while (flag)
            {

                Console.WriteLine("Options :");
                await DisplayMenus(_roleDisplaymenu);
                Console.Write("Choose any option from above:");
                string input = Console.ReadLine();
                int.TryParse(input, out int option);
                if (option == 0 && input != "0")
                {
                    Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                    RoleManagementDisplayMenu();
                    return;
                }
                switch (option)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        await _roleManagement.AddRole();
                        break;
                    case 2:
                        await  _roleManagement.DisplayAll();
                        break;

                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
        }
        private async Task DepartmentLocationDisplayMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Options:");
                await DisplayMenus(_departmentLocationDisplaymenu);
                int option;
                Console.Write("Choose any option from above:");
                string input = Console.ReadLine();
                int.TryParse(input, out option);
                if (option == 0 && input != "0")
                {
                    Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                    DepartmentLocationDisplayMenu();
                    return ;
                }
                switch (option)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        await  _departmentManagement.AddDepartment();
                        break;
                    case 2:
                        await _departmentManagement.DisplayAll();
                        break;
                    case 3:
                        await _locationManagement.AddLocation();
                        break;
                    case 4:
                        await _locationManagement.DisplayAll();
                        break;
                    case 5:
                        await _projectManagement.AddProject();
                        break;
                    case 6:
                        await _projectManagement.DisplayAll();
                        break;
                    default:
                        Console.WriteLine("Select option from the above list only\n");
                        break;
                }
            }
        }
    }
}
