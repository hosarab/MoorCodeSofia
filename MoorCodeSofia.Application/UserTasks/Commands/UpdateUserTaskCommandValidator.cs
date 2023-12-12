using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class UpdateUserTaskCommandValidator : AbstractValidator<UpdateUserTaskCommand>
    {
        public UpdateUserTaskCommandValidator()  
        {
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).NotNull().WithMessage("EndDate cannot be null or less then StartDate");
            RuleFor(x => x.EndDate).Must(BeValidDate).WithMessage("EndDate must be a validate date");
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).NotNull().WithMessage("StartDate cannot be null or less then EndDate");
            RuleFor(x => x.StartDate).Must(BeValidDate).WithMessage("StartDate must be a validate date");
            RuleFor(d => d.id)
               .NotNull()  
               .NotEmpty().WithMessage("id can not be null ");   
        }
        private bool BeValidDate(DateTime date) { return !date.Equals(default); }
    }
}
