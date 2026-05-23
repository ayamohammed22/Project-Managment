using FluentValidation;
using Project_Managment.Service.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Validation
{
    public class CreateTaskCommandRequestValidator : AbstractValidator<CreateTaskCommandRequest>
    {
        public CreateTaskCommandRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("Project ID must be greater than 0.");
        }
    }
}
