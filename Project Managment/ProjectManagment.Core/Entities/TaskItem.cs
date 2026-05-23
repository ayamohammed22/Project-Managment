using Project_Managment.Core.Enums;

namespace Project_Managment.Core.Entities
{
    public class TaskItem : BaseEntitiy
    {
        public string Title { get; set; } 

        public string Description { get; set; } 

        public TaskItemStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public TaskItemPriority Priority { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = default!;
    }
}
