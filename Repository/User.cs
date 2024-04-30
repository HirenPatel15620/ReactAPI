using Model.Data;
using Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class User : IUser
    {
        #region Inject Dependencies
        private readonly typescript_demoContext db; 
        #endregion

        #region Constructor
        public User(typescript_demoContext _db)
        {
            db = _db;
        } 
        #endregion

        #region Method
        public async Task<Model.Models.User> AddUser(Model.Models.User user)
        {
            var User = await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return User.Entity;
        }

        public async Task<bool> DeleteUser(long id)
        {
            var User = await db.Users.FindAsync(id);
            if (User is not null)
            {
                db.Users.Remove(User);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Model.Models.User>> GetAllUsers()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<Model.Models.User> GetUserById(long id)
        {
            Model.Models.User model = new();
            var user = await db.Users.FindAsync(id);
            if (user is not null)
            {
                model = user;
            }
            return model;
        }
        public async Task<Model.Models.User> GetUserByProtectedId(long id, string sid)
        {
            Model.Models.User model = new();
            var user = await db.Users.FindAsync(id);
            if (user is not null)
            {
                model.UserId = user.UserId;
                model.Title = user.Title;

                model.Body = user.Body;
            }
            return model;
        }

        public async Task<Model.Models.User> UpdateUser(Model.Models.User user)
        {
            var User = await db.Users.FindAsync(user.UserId);
            if (User is not null)
            {

                User.Title = user.Title;
                User.Body = user.Body;
                await db.SaveChangesAsync();
                return user;
            }
            return new Model.Models.User();
        } 
        #endregion
    }
}
