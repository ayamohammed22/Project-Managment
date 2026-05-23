using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Managment.Service.DTOs.Task;
using Project_Managment.Service.Interfaces;

namespace Project_Managment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            this._service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommandRequest request)
        {
            var response = await _service.CreateTask(request);
            return Ok(response);
        }

       
        [HttpPut]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] UpdateTaskStatusCommandRequest request)
        {
            var response = await _service.UpdateTask(request);
            return Ok(response);
        }
       
        [HttpGet]
        public IActionResult GetTasksForSpecificProject([FromQuery] int projectId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var request = new GetAllTasksForSpecificProjectRequest()
            {
                projectId = projectId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var response = _service.GetAllTasksForSpecificProject(request);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute]int id)
        {
            var request = new DeleteTaskCommandRequest()
            {
                Id = id
            };
            var response = await _service.DeleteTask(request);
            return Ok(response);
        }
    }
}
