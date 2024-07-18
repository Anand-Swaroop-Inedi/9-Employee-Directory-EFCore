using Presentation.Interfaces;
using Models;
using BusinessLogicLayer.Interfaces;

namespace Presentation.Services
{
    public class LocationManagement : ILocationManagement
    {
        private readonly ILocationManager _locationManager;
        public LocationManagement(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }
        public async Task AddLocation()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter Location");
            Console.Write("Choose options from above:");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            if (option == 0 && input != "0")
            {
                Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                AddLocation();
            }
            else if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                Console.Write("Enter Location Name:");
                string location = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(location))
                {
                    Location locationModel = new Location();
                    locationModel.Name = location;
                    if (await _locationManager.AddLocation(locationModel))
                    {
                        Console.WriteLine("Location Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Location already exists");
                    }
                }
                else
                {
                    Console.WriteLine("Location can't be null");
                }
            }
            else
            {
                AddLocation();
            }
        }
        public async Task DisplayAll()
        {
            List<Location> locationList = await _locationManager.GetAll();
            Console.WriteLine($"Locations(Count:{locationList.Count}):");
            for (int i = 0; i < locationList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {locationList[i].Name}");
            }
        }
    }
}
