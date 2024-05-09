using FluentValidation;
using Repository.Services.StackService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelValidators
{
    public class CreateOrUpdateStackDetailsListValidator : AbstractValidator<CreateOrUpdateStackDetailsReqModal>
    {
        public CreateOrUpdateStackDetailsListValidator(bool isNew = false)
        {
            RuleFor(x => x.StackDetailsList).Must(x => x.Count() > 0);
            RuleForEach(x => x.StackDetailsList).SetValidator(new CreateOrUpdateStackDetailsValidator(isNew));
        }
    }
}
