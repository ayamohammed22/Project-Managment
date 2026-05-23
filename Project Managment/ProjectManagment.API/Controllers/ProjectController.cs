
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Managment.Service.DTOs.Project;
using Project_Managment.Service.Interfaces;

namespace Project_Managment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommandRequest request)
        {
            var result = await service.CreateProjectAsync(request);
            return Ok(result);
        }
 
        [HttpGet]
        public IActionResult GetAllProjects([FromQuery] int? PageSize , [FromQuery] int? PageCount)

        {
            var request = new GetAllProjectsRequest()
            {
                 pageCount = PageCount,
                 pageSize = PageSize
            };
            var result = service.GetAllProjectsAsync(request);
            return Ok(result);
        }
       
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProjectById([FromRoute] int Id)
        {
            var result = await service.GetProjectByIdAsync(new GetProjectByIdRequest() { Id = Id });
            return Ok(result);
        }
       
        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommandRequest request)
        {
            var result = await service.UpdateProjectAsync(request);
            return Ok(result);

        }
      
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int Id)
        {
            var result = await service.DeleteProjectAsync(new DeleteProjectCommandRequest() { Id = Id });
            return Ok(result);
        }
    }
}
