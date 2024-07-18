using Presentation.Interfaces;

namespace Presentation.Services
{
    public class StartApp
    {
        private readonly IDisplayMenuManagement _displayMenuManagement;
        public StartApp(IDisplayMenuManagement displayMenuManagement)
        {
            _displayMenuManagement = displayMenuManagement;
        }
        public async Task Run()
        {
            await _displayMenuManagement.StartAppDisplayOptionMenu();
        }
    }
}
