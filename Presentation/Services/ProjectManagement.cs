using BusinessLogicLayer.Interfaces;
using Models;
using Presentation.Interfaces;

namespace Presentation.Services
{
    public class ProjectManagement : IProjectManagement
    {
        private readonly IProjectManager _projectManager;
        public ProjectManagement(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        public async Task<int> AddProject()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Enter Project");
            Console.Write("Choose options from above:");
            string input = Console.ReadLine();
            int.TryParse(input, out int option);
            if (option == 0 && input != "0")
            {
                Console.WriteLine("Enter the choice correctly(Only the above mentioned choices are valid");
                return await AddProject();
            }
            else if (option == 0)
            {
                return 0;
            }
            else if (option == 1)
            {
                Console.Write("Enter Project Name:");
                string project = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(project))
                {
                    Project projectModel = new Project();
                    projectModel.Name = project;
                    if (await _projectManager.AddProject(projectModel))
                    {
                        Console.WriteLine("Project Added Successfully");
                        return projectModel.Id;
                    }
                    else
                    {
                        Console.WriteLine("Project already exists");
                        return -1;
                    }
                }
                else
                {
                    Console.WriteLine("Project can't be null");
                    return await AddProject();
                }
            }
            else
            {
                return await AddProject();
            }
        }
        public async Task DisplayAll()
        {
            List<Project> projectList =await _projectManager.GetAll();
            Console.WriteLine($"Projects(Count:{projectList.Count}):");
            for (int i = 0; i < projectList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {projectList[i].Name}");
            }
        }
    }
}
