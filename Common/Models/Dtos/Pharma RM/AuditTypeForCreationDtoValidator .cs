using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Common.Models.Dtos.Pharma_RM
{

    public class AuditTypeForCreationDtoValidator : AbstractValidator<AuditTypeForCreationDto>
    {
        public AuditTypeForCreationDtoValidator()
        {
            RuleFor(x => x.TypeName)
                .NotEmpty().WithMessage("TypeName is required.")
                .MaximumLength(100).WithMessage("TypeName cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Description cannot exceed 250 characters.");
        }
    }

}
