using FluentValidation;
using Project_Managment.Service.DTOs.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Service.Validation
{
    public class UpdateProjectCommandRequestValidator : AbstractValidator<UpdateProjectCommandRequest>
    {
        public UpdateProjectCommandRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();
        }
    }
   
}
