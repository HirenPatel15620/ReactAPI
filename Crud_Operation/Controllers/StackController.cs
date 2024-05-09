using FluentValidation.Results;
using isCTv9.API.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Repository.CommonServices;
using Repository.Models;
using Repository.ModelValidators;
using Repository.Services.StackService;
using Repository.Services.UserService;

namespace Crud_Operation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StackController : Controller
    {
        #region Injected Dependencies

        private readonly IStackService _stack;

        #endregion Injected Dependencies

        #region constructor

        public StackController(IStackService stack)
        {
            _stack = stack;
        }

        #endregion constructor

        /// <summary>
        /// Retrieve All Stack
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(RetrieveStackDataDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> RetrieveAllStack()
        {
            var results = await _stack.RetrieveAllStack();
            return Ok(results);
        }

        /// <summary>
        /// Get Stack Details Id
        /// </summary>
        /// <param name="id">Stack id</param>
        /// <returns></returns>
        [HttpGet("{id:min(1)}")]
        [ProducesResponseType(typeof(List<RetrieveStackDataDto>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> RetrieveStackDetailsById([FromRoute] int id)
        {
            var status = await _stack.RetrieveStackDetailsById(id);
            return Ok(status);
        }

        /// <summary>
        /// Create stack details.
        /// </summary>
        /// <param name="payload">Create Or Update Stack Details Requset Modal</param>
        /// <returns>Status generic handler.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStackDetails([FromBody] CreateOrUpdateStackDetailsReqModal payload)
        {
            var validator = new CreateOrUpdateStackDetailsListValidator(true);

            ValidationResult modelResult = validator.Validate(payload);
            if (modelResult.IsValid)
            {
                var result = await _stack.CreateOrUpdateStackDetailsData(0, payload);
                return result.Response(ModelState, HttpContext, "");
            }
            else
            {
                return modelResult.Response(ModelState, HttpContext);
            }
        }

        /// <summary>
        /// Update stack details.
        /// </summary>
        /// <param name="id">stack id</param>
        /// <param name="payload">Create Or Update Stack Details RequestModal</param>
        /// <returns>Status generic handler.</returns>
        [HttpPut("{id:min(1)}")]
        [ProducesResponseType(typeof(CreateGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStackDetails([FromRoute] int id, [FromBody] CreateOrUpdateStackDetailsReqModal payload)
        {
            var validator = new CreateOrUpdateStackDetailsListValidator();

            ValidationResult modelResult = validator.Validate(payload);
            if (modelResult.IsValid)
            {
                var result = await _stack.CreateOrUpdateStackDetailsData(id, payload);
                return result.Response(ModelState, HttpContext, "");
            }
            else
            {
                return modelResult.Response(ModelState, HttpContext);
            }
        }
        /// <summary>
        /// Delete Stack.
        /// </summary>
        /// <param name="stackId">stack Id </param>
        /// <returns>Status generic handler.</returns>
        [HttpDelete("{stackId:min(1)}")]
        [ProducesResponseType(typeof(DeleteGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStack([FromRoute] int stackId)
        {
            var status = await _stack.DeleteStack(stackId);

            return status.Response(ModelState, HttpContext, "");
        }
    }
}