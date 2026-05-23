using FluentValidation;
using Project_Managment.Service.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Validation
{
    public class UpdateTaskStatusCommandRequestValidator : AbstractValidator<UpdateTaskStatusCommandRequest>
    {
        public UpdateTaskStatusCommandRequestValidator() 
        {
           
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
