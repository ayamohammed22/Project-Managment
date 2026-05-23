using Project_Managment.Core.Entities;
using Project_Managment.Infrastructure.Interfaces;
using Project_Managment.Service.DTOs.Project;
using Project_Managment.Service.Interfaces;

namespace Project_Managment.Application.Services
{
    public class ProjectServices : IProjectService
    {
        private readonly IRepository<Project> repo;

        public ProjectServices(IRepository<Project> Repo)
        {
            repo = Repo;

        }

        public async Task<CreateProjectCommandResponse> CreateProjectAsync(CreateProjectCommandRequest request)
        {
            var project = new Project()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            await repo.AddAsync(project);
            await repo.SaveChangesAsync();
            var projectResponse = new CreateProjectCommandResponse()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
            return projectResponse;
        }

        public List<GetAllProjectsResponse> GetAllProjectsAsync(GetAllProjectsRequest request)
        {
            if (request.pageCount == null ||request.pageCount <= 0) request.pageCount = 1;
            if (request.pageSize == null ||request.pageSize <= 0) request.pageSize = 10;
            var projects = repo.GetAll().Skip((request.pageCount.Value - 1) * request.pageSize.Value).Take(request.pageSize.Value).ToList();
            var projectResponse = projects.Select(p => new GetAllProjectsResponse()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt
            }).ToList();
            return projectResponse;
        }

        public async Task<GetProjectByIdResponse> GetProjectByIdAsync(GetProjectByIdRequest request)
        {
            var project = await repo.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            var projectResponse = new GetProjectByIdResponse()
            {
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
            return projectResponse;
        }

        public async Task<UpdateProjectCommandResponse> UpdateProjectAsync(UpdateProjectCommandRequest request)
        {
            var project = await repo.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            project.Name = request.Name;
            project.Description = request.Description;
            repo.Update(project);
            await repo.SaveChangesAsync();

            var response = new UpdateProjectCommandResponse()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
            return response;
        }

        public async Task<DeleteProjectCommandResponse> DeleteProjectAsync(DeleteProjectCommandRequest request)
        {
            var project = await repo.GetByIdAsync(request.Id);
            if(project == null)
            {
                throw new Exception("Unfound project");
            }
             repo.Delete(project);
            await repo.SaveChangesAsync();
            return new DeleteProjectCommandResponse()
            {
                message = "Project deleted successfully"
            };
        }
    }
}
