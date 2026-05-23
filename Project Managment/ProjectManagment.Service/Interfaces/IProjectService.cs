using Project_Managment.Service.DTOs.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Interfaces
{
    public interface IProjectService
    {
        public Task<CreateProjectCommandResponse> CreateProjectAsync(CreateProjectCommandRequest request);
        public List<GetAllProjectsResponse> GetAllProjectsAsync(GetAllProjectsRequest request);
        public Task<GetProjectByIdResponse> GetProjectByIdAsync(GetProjectByIdRequest request);
        public Task<UpdateProjectCommandResponse> UpdateProjectAsync(UpdateProjectCommandRequest request);
        public Task<DeleteProjectCommandResponse> DeleteProjectAsync(DeleteProjectCommandRequest request);
    }
}
