using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Managers;
using DataAccessLayer.Interface;
using DataAccessLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.Services;

namespace EmployeeReplica
{

    class Program
    {
        public async static Task Main(String[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IRoleManagement, RoleManagement>();
            services.AddTransient<IEmployeeManagement, EmployeeManagement>();
            services.AddTransient<IEmployeePropertyEntryManager, EmployeePropertyEntryManager>();
            services.AddTransient<IDepartmentManager, DepartmentManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<IRolePropertyEntryManager, RolePropertyEntryManager>();
            services.AddTransient<IProjectManagement, ProjectManagement>();
            services.AddTransient<IProjectManager, ProjectManager>();
            services.AddTransient<IDepartmentManagement, DepartmentManagement>();
            services.AddTransient<ILocationManagement, LocationManagement>();
            services.AddTransient<IDataOperations, DataOperations>();
            services.AddSingleton<StartApp>();
            services.AddTransient<IDisplayMenuManagement, DisplayMenuManagement>();
            var serviceProvider = services.BuildServiceProvider();
            var startApp = serviceProvider.GetRequiredService<StartApp>();
            await startApp.Run();
            /* myTask.Wait();*/
        }
    }
}
