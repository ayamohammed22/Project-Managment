using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Core.Entities
{
    public class Project : BaseEntitiy
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public ICollection<TaskItem> Tasks { get; set; } 
    }
}
