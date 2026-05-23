using Project_Managment.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.DTOs.Task
{
    public class UpdateTaskStatusCommandRequest
    {
        public int Id { get; set; }
        public TaskItemStatus Status { get; set; }
    }
}
