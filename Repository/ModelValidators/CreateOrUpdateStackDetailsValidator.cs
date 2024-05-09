using FluentValidation;
using Repository.Services.StackService;
using ServiceLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelValidators
{
    public class CreateOrUpdateStackDetailsValidator : AbstractValidator<CreateOrUpdateStackDetailsModal>
    {
        public CreateOrUpdateStackDetailsValidator(bool isNew = false)
        {
            if (!isNew)
            {
                RuleFor(x => x.StackId)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage(string.Format(ServiceMessages.Message_ValidatorFieldRequired, "Stack Id"));
            }

            RuleFor(x => x.Name)
                    .Cascade(CascadeMode.Stop)
                    .NotNull().NotEmpty().WithMessage(string.Format(ServiceMessages.Message_ValidatorFieldRequired, "Name"));

        }
    }
}
