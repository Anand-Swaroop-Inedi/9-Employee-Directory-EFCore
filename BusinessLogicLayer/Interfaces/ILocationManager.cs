using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILocationManager
    {
        public Task<bool> AddLocation(Location location);
        public Task<List<Location>> GetAll();
    }
}
