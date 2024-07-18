namespace Presentation.Interfaces
{
    public interface IProjectManagement
    {
        public Task<int> AddProject();
        public Task DisplayAll();
    }
}
