using DataAccessLayer.Interface;
using BusinessLogicLayer.Interfaces;
using Models;

namespace BusinessLogicLayer.Managers
{
    public class LocationManager : ILocationManager
    {
        private readonly IDataOperations _dataOperations;
        public LocationManager(IDataOperations dataOperations)
        {
            _dataOperations = dataOperations;   
        }

        public async Task<bool> AddLocation(Location location)
        {
            List<Location> locationList =GetAll().Result;

            if (!CheckLocationExists(location.Name, locationList))
            {
                locationList.Add(location);
                if(await _dataOperations.AddLocationToDb(location))
                {
                    return true;
                }
            }
                return false;
        }

        public async Task<List<Location>> GetAll()
        {
            return await _dataOperations.GetLocations();
        }
        public static bool CheckLocationExists(string loc, List<Location> locationList)
        {
            for (int i = 0; i < locationList.Count; i++)
            {
                if (locationList[i].Name == loc)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
