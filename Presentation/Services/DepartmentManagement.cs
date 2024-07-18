using Presentation.Interfaces;
using Models;
using BusinessLogicLayer.Interfaces;

namespace Presentation.Services
{
    public class DepartmentManagement : IDepartmentManagement
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentManagement(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        public async Task AddDepartment()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter Department");
            Console.Write("Choose options from above:");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            if (option == 0 && input != "0")
            {
                Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                AddDepartment();
            }
            else if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                Console.Write("Enter Department Name:");
                string department = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(department))
                {
                    Department departmentModel = new Department { Name = department };

                    if (await _departmentManager.AddDepartment(departmentModel))
                    {
                        Console.WriteLine("Department Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Department already exists");
                    }
                }
                else
                {
                    Console.WriteLine("Department can't be null");
                }
            }
        }
        public async Task DisplayAll()
        {
            List<Department> departmentList =await _departmentManager.GetAll();
            Console.WriteLine($"Department List(Count:{departmentList.Count}):");
            for (int i = 0; i < departmentList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {departmentList[i].Name}");
            }
        }
    }
}
