using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Repository.Interface;

namespace Crud_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        #region Injected Dependencies
        private readonly IUser repo;
        private readonly typescript_demoContext _db;
        #endregion

        #region constructor
        public UserController(IUser _repo, typescript_demoContext db)
        {
            _db = db;
            repo = _repo;
        }
        #endregion

        #region CRUD operation

        [HttpGet("/user/getall")]
        public async Task<ActionResult<IEnumerable<User>>> Ge()
        {
            if (_db.Users == null)
            {
                return NotFound();
            }
            return await _db.Users.ToListAsync();
        }

        [HttpGet("/user/get")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            if (_db.Users == null)
            {
                return NotFound();
            }
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();

            }

            return Ok(user);

        }

        [HttpPost("/user/add")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }



        [HttpPut("/user/update/{id}")]
        public async Task<ActionResult> PutUser(long id, User user)
        {

            if (id != user.UserId)
            {
                return BadRequest();
            }
            _db.Entry(user).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("/user/delete/{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            if (_db.Users == null)
            {
                return NotFound();
            }
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
