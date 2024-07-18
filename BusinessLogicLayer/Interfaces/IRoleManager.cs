using Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        public Task<bool> AddRole(Roles rolesModel);
        public Task<bool> CheckRoleExists(string roleName);
        public Task<List<Roles>> GetAll();
        public Task<string> GetRoleName(int id);
    }
}
