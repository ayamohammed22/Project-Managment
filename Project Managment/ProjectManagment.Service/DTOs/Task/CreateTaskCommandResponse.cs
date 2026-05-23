using Project_Managment.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.DTOs.Task
{
    public class CreateTaskCommandResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TaskItemStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public TaskItemPriority Priority { get; set; }

        public int ProjectId { get; set; }
    }
}
