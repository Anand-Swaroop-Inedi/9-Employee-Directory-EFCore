namespace Presentation.Interfaces
{
    public interface IRoleManagement
    {
        public Task<int> AddRole();
        public Task DisplayAll();
    }
}
