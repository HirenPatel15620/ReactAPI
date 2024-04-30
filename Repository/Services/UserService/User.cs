using Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Services.UserService;
using ServiceLayer.Utilities;
using StatusGeneric;
using Model.Models;
using Repository.Models;
using ServiceLayer.Constants;

namespace Repository
{
    public interface IUser
    {
        #region Interfaces
        Task<List<RetrieveUserDataDto>> RetrieveGetAllUser();
        Task<RetrieveUserDataDto> GetUserById(long id);
        Task<IStatusGenericAdapter> CreateOrUpdateUser(int userid, CreateOrUpdateUserReqModel payload);
        Task<IStatusGenericAdapter> DeleteUser(long id);
        #endregion
    }
    public class User : IUser
    {
        #region Inject Dependencies
        private readonly typescript_demoContext _db;
        #endregion

        #region Constructor
        public User(typescript_demoContext db)
        {
            _db = db;
        }
        #endregion

        #region Method

        public async Task<List<RetrieveUserDataDto>> RetrieveGetAllUser()
        {

            var status = new List<RetrieveUserDataDto>();
            var userQuery = from user in _db.Users
                            select new RetrieveUserDataDto
                            {
                                Body = user.Body,
                                Title = user.Title,
                                UserId = user.UserId
                            };

            return await userQuery.ToListAsync();

        }

        public async Task<RetrieveUserDataDto> GetUserById(long id)
        {
            var userQuery = from user in _db.Users
                            where user.UserId == id
                            select new RetrieveUserDataDto
                            {
                                Body = user.Body,
                                Title = user.Title,
                                UserId = user.UserId
                            };
            var userData = await userQuery.FirstOrDefaultAsync();
            return userData;
        }

        public async Task<IStatusGenericAdapter> CreateOrUpdateUser(int userid, CreateOrUpdateUserReqModel payload)
        {
            var status = new StatusGenericHandler<CreateGenericResponseDto>();

            payload.UserId = userid;
            bool isNew = payload.UserId == 0 ? true : false;
            Model.Models.User data;

            if (isNew)
            {
                if (_db.Users.Where(x => x.UserId == payload.UserId).Any())
                {
                    status.AddError("Duplicate User.", nameof(Model.Models.User));
                    return status.AddState(StatusGenericState.None);
                }
                data = new Model.Models.User();
            }
            else
            {
                data = await _db.Users.Where(x => x.UserId == userid).FirstOrDefaultAsync();
                if (data == null)
                {
                    status.AddError(string.Format(ServiceMessages.Message_RecordNotFound, "User"), nameof(Model.Models.User));
                    return status.AddState(StatusGenericState.None);
                }
            }
            data.Title = payload.Title;
            data.Body = payload.Body;


            var stragegy = _db.Database.CreateExecutionStrategy();
            await stragegy.ExecuteAsync(async () =>
            {
                using var transaction = await _db.Database.BeginTransactionAsync();
                try
                {
                    if (isNew)
                        await _db.Users.AddAsync(data);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });

            status.SetResult(new CreateGenericResponseDto() { ID = Convert.ToInt32(data.UserId), Success = true });
            return status.AddState(isNew ? StatusGenericState.Created : StatusGenericState.Modified);

        }


        public async Task<IStatusGenericAdapter> DeleteUser(long id)
        {
            var status = new StatusGenericHandler<DeleteGenericResponseDto>();

            var user = await _db.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (user is null)
            {
                status.AddError(string.Format(ServiceMessages.Message_RecordNotFound, "User"), nameof(Model.Models.User));
                return status.AddState(StatusGenericState.None);
            }

            var stragegy = _db.Database.CreateExecutionStrategy();

            await stragegy.ExecuteAsync(async () =>
            {
                using var transaction = await _db.Database.BeginTransactionAsync();

                try
                {
                    _db.Users.Remove(user);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });

            status.SetResult(new DeleteGenericResponseDto() { ID = Convert.ToInt32(id), Success = true });
            return status.AddState(StatusGenericState.Deleted);
        }



      
        #endregion
    }
}
