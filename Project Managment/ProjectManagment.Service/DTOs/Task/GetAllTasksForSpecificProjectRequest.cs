using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.DTOs.Task
{
    public class GetAllTasksForSpecificProjectRequest
    {
        public int projectId { get; set; }
        public int ? PageNumber { get; set; } 
        public int ? PageSize { get; set; }
    }
}
