using FluentValidation;
using Project_Managment.Service.DTOs.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Validation
{
    public class CreateProjectCommandRequestValidator : AbstractValidator<CreateProjectCommandRequest>
    {
        public CreateProjectCommandRequestValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();
        }
    }
}
