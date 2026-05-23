using Project_Managment.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.DTOs.Task
{
    public class GetAllTasksForSpecificProjectResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } 

        public string Description { get; set; } 

        public TaskItemStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public TaskItemPriority Priority { get; set; }
    }
}
