using BusinessLogicLayer.Interfaces;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public sealed class RoleManagement : IRoleManagement
    {

        private readonly IRoleManager _roleManager;
        private readonly IRolePropertyEntryManager _rolePropertyEntryManager;
        public RoleManagement(IRoleManager roleManager, IRolePropertyEntryManager rolePropertyEntryManager)
        {
            _roleManager = roleManager;
            _rolePropertyEntryManager = rolePropertyEntryManager;
        }

        private async Task<bool> GetRoleDetailsInput(Roles role)
        {
            Console.WriteLine("Roles");
            role.Department = await _rolePropertyEntryManager.ChooseDepartment();
            if (role.Department == "Exit")
            {
                return false;
            }
            Console.WriteLine("Roles");
            role.Location = await _rolePropertyEntryManager.ChooseLocation();
            if (role.Location == "Exit")
            {
                return false;
            }
            role.Description = _rolePropertyEntryManager.GetDescription();
            if (role.Description == "Abort")
            {
                return false;
            }
            return true;
        }
        public async Task<int> AddRole()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter New Role:");
            Console.Write("Choose option from above:");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            if (option == 0 && input != "0")
            {
                Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                return AddRole().Result;
            }
            else if (option == 0)
            {
                return 0;
            }
            else if (option == 1)
            {
                Console.Write("Enter Role Name:");
                string roleName = Console.ReadLine()!.ToUpper();
                if (!await _roleManager.CheckRoleExists(roleName))
                {
                    Roles roleModel = new Roles();
                    roleModel.Name = roleName;
                    bool result = await GetRoleDetailsInput(roleModel);
                    if (result && await _roleManager.AddRole(roleModel))
                    {
                        Console.WriteLine($"New Role Added Successfully");
                        return roleModel.Id;
                    }
                    else
                    {
                        Console.WriteLine("Failed to Add Role");
                        return -1;
                    }

                }
                else
                {
                    Console.WriteLine("Role Exists Previously in the database so u can't add again");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("Choose from above options only.");
                return await AddRole();
            }
        }
        public async Task DisplayAll()
        {
            List<Roles> roleList = await _roleManager.GetAll();
            Console.WriteLine("{0,-8} {1,-24} {2,-18} {3,-12} {4,-18}","Index", "Role Name", "Department", "Location", "Description");
            for (int i = 0; i < roleList.Count; i++)
            {
                Console.WriteLine(new string('-', 66));
                Console.WriteLine("{0,-8} {1,-24} {2,-18} {3,-12} {4,-18}", i+1,roleList[i].Name, roleList[i].Department, roleList[i].Location, roleList[i].Description);
            }
        }

    }
}
