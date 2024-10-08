﻿using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Repository.FilterModels;
using Repository.Models;
using Repository.Services.UserService;
using Repository.Services.UserService.Dto;
using Repository.Services.UserService.QueryObjects;
using ServiceLayer.Constants;
using ServiceLayer.Generics;
using ServiceLayer.Utilities;
using StatusGeneric;

namespace Repository
{
    public interface IUser
    {
        #region Interfaces

        Task<UserListDataListDto> RetrieveGetAllUser(UserListDataFilter userListDataFilter);

        Task<RetrieveUserDataDto> GetUserById(long id);

        Task<IStatusGenericAdapter> CreateOrUpdateUser(int userid, CreateOrUpdateUserReqModel payload);

        Task<IStatusGenericAdapter> DeleteUser(long id);

        Task<RetriveDragAndDropListDto> RetrieveDragAndDrop();

        #endregion Interfaces
    }

    public class UserService : IUser
    {
        #region Inject Dependencies

        private readonly typeScript_demoContext _context;

        #endregion Inject Dependencies

        #region Constructor

        public UserService(typeScript_demoContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Method

        public async Task<UserListDataListDto> RetrieveGetAllUser(UserListDataFilter userListDataFilter)
        {
            IQueryable<User> userListQuery = null;
            List<User> userListData = new List<User>();
            int totalRecords = 0;

            userListQuery = from data in _context.Users
                            select data;

            for (var i = 0; i < userListDataFilter.FilterBys.Count; i++)
            {
                var filterBy = userListDataFilter.FilterBys[i];

                var filterValue = userListDataFilter.FilterValues[i];

                if (filterValue != null)
                {
                    userListQuery = userListQuery.FilteUserListDataBy(filterBy, filterValue);
                }
            }

            totalRecords = await userListQuery.CountAsync();

            if (userListDataFilter.PaginationEnabled == true)
            {
                userListData = await userListQuery
                    .OrderUserListDataBy(userListDataFilter)
                    .Page(userListDataFilter.PageNumber, userListDataFilter.PageSize)
                    .ToListAsync();
                return new UserListDataListDto(totalRecords, userListDataFilter.PageSize, userListData);
            }
            else
            {
                userListData = await userListQuery
                    .OrderUserListDataBy(userListDataFilter)
                    .ToListAsync();
                return new UserListDataListDto(totalRecords, totalRecords, userListData);
            }
        }

        public async Task<RetrieveUserDataDto> GetUserById(long id)
        {
            var userQuery = from user in _context.Users
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
            Model.Models.User? data;

            if (isNew)
            {
                if (await _context.Users.Where(x => x.UserId == payload.UserId).AnyAsync())
                {
                    status.AddError("Duplicate User.", nameof(Model.Models.User));
                    return status.AddState(StatusGenericState.None);
                }
                data = new Model.Models.User();
            }
            else
            {
                data = await _context.Users.Where(x => x.UserId == userid).FirstOrDefaultAsync();
                if (data == null)
                {
                    status.AddError(string.Format(ServiceMessages.Message_RecordNotFound, "User"), nameof(Model.Models.User));
                    return status.AddState(StatusGenericState.None);
                }
            }
            data.Title = payload.Title;
            data.Body = payload.Body;

            var stragegy = _context.Database.CreateExecutionStrategy();
            await stragegy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (isNew)
                        await _context.Users.AddAsync(data);

                    await _context.SaveChangesAsync();
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

            var user = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (user is null)
            {
                status.AddError(string.Format(ServiceMessages.Message_RecordNotFound, "User"), nameof(Model.Models.User ));
                return status.AddState(StatusGenericState.None);
            }

            var stragegy = _context.Database.CreateExecutionStrategy();

            await stragegy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    _context.Users.Remove(user);

                    await _context.SaveChangesAsync();
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

        public async Task<RetriveDragAndDropListDto> RetrieveDragAndDrop()
        {
            IQueryable<DragAndDrop> DragAndDropListQuery = null;
            List<DragAndDrop> DragAndDropData = new List<DragAndDrop>();
            int totalRecords = 0;

            DragAndDropListQuery = from dragAndDrops in _context.DragAndDrops
                                   select dragAndDrops;

            totalRecords = await DragAndDropListQuery.CountAsync();

            DragAndDropData = await DragAndDropListQuery.ToListAsync();
            return new RetriveDragAndDropListDto(totalRecords, totalRecords, DragAndDropData);
        }

        #endregion Method
    }
}