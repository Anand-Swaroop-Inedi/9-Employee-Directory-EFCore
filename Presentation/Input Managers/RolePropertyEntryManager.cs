using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Managers;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services;

public class RolePropertyEntryManager : IRolePropertyEntryManager
{
    private readonly IDepartmentManager _manager;
    private readonly ILocationManager _locationManager;
    public RolePropertyEntryManager(IDepartmentManager manager, ILocationManager locationManager)
    {
        _manager = manager;
        _locationManager = locationManager;
    }
    public string GetDescription()
    {
        string description = "";
        Console.WriteLine("Description:");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Upload Later");
        Console.WriteLine("2. Enter Description");
        Console.Write("Choose from above options:");
        int.TryParse(Console.ReadLine(), out int option);
        switch (option)
        {
            case 0: return "Abort";
            case 1:
                description = "NONE";
                return description;
            case 2:
                Console.Write("Enter the Description:");
                description = Console.ReadLine();
                if (description == "")
                {
                    return GetDescription();
                }
                else
                {
                    return description;
                }

            default:
                Console.WriteLine("Select option from the above list only");
                return GetDescription();
        }
    }
    public static void DisplayList(List<Department> departmentList)
    {
        for (int i = 0; i < departmentList.Count; i++)
        {
            Console.WriteLine($"{i + 2}.  {departmentList[i].Name}");
        }
    }
    public static void DisplayLocationList(List<Location> locations)
    {
        for (int i = 0; i < locations.Count; i++)
        {
            Console.WriteLine($"{i + 2}.  {locations[i].Name}");
        }
    }
    public async Task<string> ChooseDepartment()
    {
        List<Department> departmentList = await _manager.GetAll();
        int option;
        Console.WriteLine("Departments:");
        Console.WriteLine("0.Exit");
        Console.WriteLine("1. Add New Department");
        DisplayList(departmentList);
        Console.Write("Choose Department from above options*:");
        int.TryParse(Console.ReadLine(), out option);
        if (option == 0)
        {
            return "Exit";
        }
        if (option == 1)
        {
            Console.Write("Enter New DepartMent Name:");
            string name = Console.ReadLine().ToUpper();
            return name;
        }
        if (option > 1 && option <= departmentList.Count + 1)
        {
            return departmentList[option - 2].Name;
        }
        else
        {
            Console.WriteLine("Select option from the above list only");
            return await ChooseDepartment();
        }
    }
    public async Task<string> ChooseLocation()
    {
        List<Location> locationList = await _locationManager.GetAll();
        Console.WriteLine("Locations:");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Add New Location");
        DisplayLocationList(locationList);
        Console.Write("Choose Location from above options:");
        int option;
        int.TryParse(Console.ReadLine(), out option);
        if (option == 0)
        {
            return "Exit";
        }
        if (option == 1)
        {
            Console.Write("Enter new Location:");
            string location = Console.ReadLine().ToUpper();
            return location;

        }
        if (option > 1 && option <= locationList.Count + 1)
        {
            return locationList[option - 2].Name;
        }
        else
        {
            Console.WriteLine("Select option from the above list only");
            return await ChooseLocation();
        }
    }
}
