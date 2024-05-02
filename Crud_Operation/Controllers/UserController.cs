using FluentValidation.Results;
using isCTv9.API.Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Repository;
using Repository.CommonServices;
using Repository.Models;
using Repository.ModelValidators;
using Repository.Services.UserService;

namespace Crud_Operation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        #region Injected Dependencies
        private readonly IUser _user;
        private readonly typescript_demoContext _db;
        #endregion

        #region constructor
        public UserController(IUser user, typescript_demoContext db)
        {
            _db = db;
            _user = user;
        }
        #endregion

        #region CRUD operation
        /// <summary>
        /// Retrieve Get All User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(RetrieveUserDataDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> RetrieveGetAllUser()
        {
            var results = await _user.RetrieveGetAllUser();
            return Ok(results);
        }

        /// <summary>
        /// Get UserBy Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:min(1)}")]
        [ProducesResponseType(typeof(RetrieveUserDataDto), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> RetrieveUserById([FromRoute] long id)
        {
            var status = await _user.GetUserById(id);
            return Ok(status);
        }

  
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

        [HttpPut("{id:min(1)}")]
        [ProducesResponseType(typeof(CreateGenericResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] CreateOrUpdateUserReqModel payload)
        {

            var validator = new CreateOrUpdateUserValidator(true);

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
