using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using StatusGeneric;
using System.Diagnostics;
using System.Net.Http;
using ServiceLayer.Utilities;
using System;
using FluentValidation.Results;

namespace isCTv9.API.Core.Utilities
{
    public static class ControllerExtensions
    {
        public static IActionResult Response(this IStatusGeneric<object> status, ModelStateDictionary modelState, HttpContext httpContext)
        {
            if (!status.HasErrors)
            {
                return new OkObjectResult(status.Result);
            }

            status.AddToModelState(modelState);

            return MakeBadRequest(modelState, httpContext);

        }

        public static IActionResult Response(this IStatusGeneric<bool> status, ModelStateDictionary modelState, HttpContext httpContext)
        {
            if (!status.HasErrors)
            {
                return new OkObjectResult(status.Result);
            }

            status.AddToModelState(modelState);

            return MakeBadRequest(modelState, httpContext);

        }

        public static IActionResult Response(this IStatusGeneric status, ModelStateDictionary modelState, HttpContext httpContext)
        {
            if (!status.HasErrors)
            {
                return new OkResult();
            }

            status.AddToModelState(modelState);

            return MakeBadRequest(modelState, httpContext);

        }

        public static IActionResult Response(this IStatusGenericAdapter status, ModelStateDictionary modelState, HttpContext httpContext, string path, string route = null)
        {
            if (!status.StatusGeneric.HasErrors)
            {
                var uri = new Uri(httpContext.Request.Scheme + "://" + httpContext.Request.Host.Value + "/" + path + (route == null ? string.Empty : "/" + route));

                return status.State == StatusGenericState.Created ? new CreatedResult(uri, status.StatusGeneric.Result) : new OkObjectResult(status.StatusGeneric.Result);
            }

            status.StatusGeneric.AddToModelState(modelState);

            return MakeBadRequest(modelState, httpContext);

        }

        public static IActionResult Response(this ModelStateDictionary modelState, HttpContext httpContext)
        {
            return MakeBadRequest(modelState, httpContext);
        }

        public static IActionResult Response(this ValidationResult result, ModelStateDictionary modelState, HttpContext httpContext)
        {
            result.AddToModelState(modelState);

            return MakeBadRequest(modelState, httpContext);
        }

        private static BadRequestObjectResult MakeBadRequest(ModelStateDictionary modelState, HttpContext httpContext)
        {
            var problemDetails = new ValidationProblemDetails(modelState)
            {
                Type = $"https://httpstatuses.io/400"
            };

            problemDetails.Extensions["traceId"] = Activity.Current?.Id ?? httpContext?.TraceIdentifier;

            return new BadRequestObjectResult(problemDetails);
        }

        public static IActionResult ResponseNewError(this ModelStateDictionary modelState, HttpContext httpContext, string errorMessage, string errorProperty = null)
        {
            modelState.AddModelError(errorProperty == null ? "Error" : errorProperty, errorMessage);

            return MakeBadRequest(modelState, httpContext);
        }
    }
}
