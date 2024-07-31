using FluentValidation.Results;
using isCTv9.API.Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Repository;
using Repository.CommonServices;
using Repository.FilterModels;
using Repository.Models;
using Repository.ModelValidators;
using Repository.Services.UserService;
using Repository.Services.UserService.Dto;

namespace Crud_Operation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        #region Injected Dependencies
        private readonly IUser _user;
        #endregion

        #region constructor
        public UserController(IUser user)
        {
            _user = user;
        }
        #endregion

        #region CRUD operation
        /// <summary>
        /// Retrieve Get All User
        /// </summary>
        /// <returns>Retrieve User Data Dto</returns>
        [HttpGet]
        [ProducesResponseType(typeof(UserListDataListDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> RetrieveGetAllUser([FromQuery] UserListDataFilter userListDataFilter)
        {
            var results = await _user.RetrieveGetAllUser(userListDataFilter);
            return Ok(results);
        }

        /// <summary>
        /// Get UserBy Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retrieve User Data Dto</returns>
        [HttpGet("{id:min(1)}")]
        [ProducesResponseType(typeof(RetrieveUserDataDto), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> RetrieveUserById([FromRoute] long id)
        {
            var status = await _user.GetUserById(id);
            return Ok(status);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="payload">Create Or Update User Request Model</param>
        /// <returns>Create Generic Response Dto</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] CreateOrUpdateUserReqModel payload)
        {
            var validator = new CreateOrUpdateUserValidator(true);

            ValidationResult modelResult = validator.Validate(payload);

            if (modelResult.IsValid)
            {
                var result = await _user.CreateOrUpdateUser(0,payload);
                return result.Response(ModelState, HttpContext, "");
            }
            else
            {
                return modelResult.Response(ModelState, HttpContext);
            }

        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id">user id </param>
        /// <param name="payload">Create Or Update User Request Model</param>
        /// <returns>Create Generic Response Dto</returns>
        [HttpPut("{id:min(1)}")]
        [ProducesResponseType(typeof(CreateGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] CreateOrUpdateUserReqModel payload)
        {
            var validator = new CreateOrUpdateUserValidator();

            ValidationResult modelResult = validator.Validate(payload);

            if (modelResult.IsValid)
            {
                var result = await _user.CreateOrUpdateUser(Convert.ToInt32(id), payload);
                return result.Response(ModelState, HttpContext, "");
            }
            else
            {
                return modelResult.Response(ModelState, HttpContext);
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">user id </param>
        /// <returns>Delete Generic Response Dto</returns>
        [ProducesResponseType(typeof(DeleteGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:min(1)}")]
        public async Task<IActionResult> DeleteUser([FromRoute]long id)
        {
            var status = await _user.DeleteUser(Convert.ToInt32(id));
            return status.Response(ModelState, HttpContext, "");
        }
        #endregion
    }
}
