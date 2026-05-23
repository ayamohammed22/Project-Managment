using Project_Managment.Service.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Interfaces
{
    public interface ITaskService
    {
        public Task<CreateTaskCommandResponse> CreateTask(CreateTaskCommandRequest request);
        public Task<UpdateTaskStatusCommandResponse> UpdateTask(UpdateTaskStatusCommandRequest request);
        public List<GetAllTasksForSpecificProjectResponse> GetAllTasksForSpecificProject(GetAllTasksForSpecificProjectRequest request);
        public Task<DeleteTaskCommandResponse> DeleteTask(DeleteTaskCommandRequest request);
    }
}
