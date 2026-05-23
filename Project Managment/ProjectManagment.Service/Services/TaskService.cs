using Microsoft.EntityFrameworkCore.Storage.Json;
using Project_Managment.Core.Entities;
using Project_Managment.Infrastructure.Interfaces;
using Project_Managment.Service.DTOs.Task;
using Project_Managment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskItem> taskRepository;
        private readonly IRepository<Project> projectRepository;

        public TaskService(IRepository<TaskItem> taskRepository, IRepository<Project> projectRepository)
        {
            this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
        }
        public async Task<CreateTaskCommandResponse> CreateTask(CreateTaskCommandRequest request)
        {
            var project = await projectRepository.GetByIdAsync(request.ProjectId);
            if(project == null)
            {
                throw new Exception("Project not found");
            }
            var task = new TaskItem()
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Priority = request.Priority,
                Status = request.Status,
                ProjectId = request.ProjectId
            };
            await taskRepository.AddAsync(task);
            await taskRepository.SaveChangesAsync();

            var reponse = new CreateTaskCommandResponse()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                ProjectId = task.ProjectId
            };
            return reponse;
        }

        public async Task<UpdateTaskStatusCommandResponse> UpdateTask(UpdateTaskStatusCommandRequest request)
        {
            var task = await taskRepository.GetByIdAsync(request.Id);
            if (task == null)
            {
                throw new Exception("Task not found");
            }
            task.Status = request.Status;
            taskRepository.Update(task);
            await taskRepository.SaveChangesAsync();
            return new UpdateTaskStatusCommandResponse()
            {
                message = "Task status updated successfully"
            };

        }

        public List<GetAllTasksForSpecificProjectResponse> GetAllTasksForSpecificProject(GetAllTasksForSpecificProjectRequest request)
        {
            if (request.PageNumber == null||request.PageNumber.Value <= 0) request.PageNumber = 1;
            if (request.PageSize == null ||request.PageSize.Value <= 0) request.PageSize = 10;

            var tasks = taskRepository.GetAll().Where(task => task.ProjectId == request.projectId)
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value).Take(request.PageSize.Value).ToList();

            var tasksResponse = tasks.Select(task => new GetAllTasksForSpecificProjectResponse()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status
            }).ToList();

            return tasksResponse;
        }

        public async Task<DeleteTaskCommandResponse> DeleteTask(DeleteTaskCommandRequest request)
        {
            var task = await taskRepository.GetByIdAsync(request.Id);
            if (task == null)
            {
                throw new Exception("Task not found");
            }
            taskRepository.Delete(task);
            await taskRepository.SaveChangesAsync();
            return new DeleteTaskCommandResponse()
            {
                message = "Task deleted successfully"
            };

        }
    }
}
