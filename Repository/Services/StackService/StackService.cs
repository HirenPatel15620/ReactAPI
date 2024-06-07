using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Repository.FilterModels;
using Repository.Models;
using Repository.Services.StackService.Dto;
using Repository.Services.StackService.QueryObjects;
using Repository.Services.UserService.Dto;
using ServiceLayer.Constants;
using ServiceLayer.Generics;
using ServiceLayer.Utilities;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.StackService
{
    public interface IStackService
    {
        Task<StackListDataListDto> RetrieveAllStack(StackListDataFilter stackListDataFilter);
        Task<List<RetrieveStackDataDto>> RetrieveStackDetailsById(int id);
        Task<IStatusGenericAdapter> CreateOrUpdateStackDetailsData(int id, CreateOrUpdateStackDetailsReqModal payload);
        Task<IStatusGenericAdapter> DeleteStack(int stackId);

    }

    public class StackService : IStackService
    {
        #region Inject Dependencies
        private readonly typeScript_demoContext _context;
        #endregion

        #region Constructor
        public StackService(typeScript_demoContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<StackListDataListDto> RetrieveAllStack(StackListDataFilter stackListDataFilter)
        {

            IQueryable<Stack> stackListQuery = null;
            List<Stack> stackListData = new List<Stack>();
            int totalRecords = 0;

            stackListQuery = from stack in _context.Stacks
                         select stack;


            for (var i = 0; i < stackListDataFilter.FilterBys.Count; i++)
            {
                var filterBy = stackListDataFilter.FilterBys[i];

                var filterValue = stackListDataFilter.FilterValues[i];

                if (filterValue != null)
                {
                    stackListQuery = stackListQuery.FilteStackListDataBy(filterBy, filterValue);
                }
            }

            totalRecords = await stackListQuery.CountAsync();

            if (stackListDataFilter.PaginationEnabled == true)
            {
                stackListData = await stackListQuery
                    .OrderStackListDataBy(stackListDataFilter)
                    .Page(stackListDataFilter.PageNumber, stackListDataFilter.PageSize)
                    .ToListAsync();
                return new StackListDataListDto(totalRecords, stackListDataFilter.PageSize, stackListData);
            }
            else
            {
                stackListData = await stackListQuery
                    .OrderStackListDataBy(stackListDataFilter)
                    .ToListAsync();
                return new StackListDataListDto(totalRecords, totalRecords, stackListData);
            }
        }

        public async Task<List<RetrieveStackDataDto>> RetrieveStackDetailsById(int id)
        {
            var stackDetailsQuery = from stack in _context.Stacks
                                    join stackDetails in _context.StackDetails on stack.Id equals stackDetails.StackId
                                    where stack.Id == id
                                    group stackDetails by new { Id = stack.Id, Title = stack.Name } into grp
                                    select new RetrieveStackDataDto
                                    {
                                        Id = grp.Key.Id,
                                        Title = grp.Key.Title,
                                        stackDetailsDataList = grp.Select(x => new RetrieveStackDetailsDataDto
                                        {
                                            StackId = x.StackId,
                                            Name = x.Name
                                        }).ToList(),
                                    };


            var stackDetailsData = await stackDetailsQuery.ToListAsync();
            return stackDetailsData;
        }

        public async Task<IStatusGenericAdapter> CreateOrUpdateStackDetailsData(int id, CreateOrUpdateStackDetailsReqModal payload)
        {
            var status = new StatusGenericHandler<CreateGenericResponseDto>();

            bool isNew = id == 0 ? true : false;
            Model.Models.Stack stack;

            if (isNew)
            {
                stack = new Model.Models.Stack();
            }
            else
            {
                stack = await _context.Stacks.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (stack == null)
                {
                    status.AddError(string.Format(ServiceMessages.Message_RecordNotFound, "Stack"), nameof(Model.Models.Stack));
                    return status.AddState(StatusGenericState.None);
                }
            }
            stack.Name = payload.Title;

            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (!isNew)
                    {
                        var clearList = await _context.StackDetails.Where(x => x.StackId == id).ToListAsync();
                        _context.StackDetails.RemoveRange(clearList);
                    }
                    if (isNew)
                    {
                        _context.Stacks.Add(stack);
                    await _context.SaveChangesAsync();
                    }

                    var stackDetailList = new List<Model.Models.StackDetail>();
                    foreach (var item in payload.StackDetailsList)
                    {
                        var newStackDetail = new Model.Models.StackDetail
                        {
                            Name = item.Name,
                            StackId = stack.Id
                        };
                        stackDetailList.Add(newStackDetail);
                    }


                        await _context.StackDetails.AddRangeAsync(stackDetailList);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });

            status.SetResult(new CreateGenericResponseDto() { ID = stack.Id, Success = true });
            return status.AddState(isNew ? StatusGenericState.Created : StatusGenericState.Modified);
        }

        public async Task<IStatusGenericAdapter> DeleteStack(int stackId)
        {
            var status = new StatusGenericHandler<DeleteGenericResponseDto>();


            var cd = await _context.Stacks.Where(x => x.Id == stackId).FirstOrDefaultAsync();

            var stackDetails = await _context.StackDetails.Where(x => x.StackId == stackId).ToListAsync();

            if (cd == null)
            {
                status.AddError(string.Format(ServiceMessages.Message_RecordNotFound, "stack"), nameof(Stack));
                return status.AddState(StatusGenericState.None);
            }

            var stragegy = _context.Database.CreateExecutionStrategy();

            await stragegy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    _context.StackDetails.RemoveRange(stackDetails);

                    _context.Stacks.Remove(cd);

                    await _context.SaveChangesAsync();


                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }

            });

            status.SetResult(new DeleteGenericResponseDto() { ID = stackId, Success = true });
            return status.AddState(StatusGenericState.Deleted);
        }

    }
}
