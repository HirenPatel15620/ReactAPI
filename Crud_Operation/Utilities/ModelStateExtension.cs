using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isCTv9.API.Core.Utilities
{
    public static class ModelStateExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
        }

        public static void AddToModelState(this IStatusGeneric result, ModelStateDictionary modelState)
        {
            if (result.HasErrors)
            {
                int i = 1;
                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(error.ErrorResult.MemberNames.Any() ? error.ErrorResult.MemberNames.First() : "Error " + i++, error.ErrorResult.ErrorMessage);
                }

            }

        }
    }
}
