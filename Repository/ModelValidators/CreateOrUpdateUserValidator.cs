using FluentValidation;
using Repository.Services.UserService;
using ServiceLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelValidators
{
    public class CreateOrUpdateUserValidator : AbstractValidator<CreateOrUpdateUserReqModel>
    {
        public CreateOrUpdateUserValidator(bool isNew = false)
        {
            if (!isNew)
            {
                RuleFor(x => x.UserId)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage(string.Format(ServiceMessages.Message_ValidatorFieldRequired, "Status Id"));
            }

            RuleFor(x => x.Title)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage(string.Format(ServiceMessages.Message_ValidatorFieldRequired, "Status Name"));

            RuleFor(x => x.Body)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage(string.Format(ServiceMessages.Message_ValidatorFieldRequired, "Display Name"));
        }

    }
}





