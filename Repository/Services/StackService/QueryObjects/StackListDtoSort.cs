using Microsoft.Extensions.Options;
using Model.Models;
using Repository.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.StackService.QueryObjects
{
    public static class StackListDtoSort
    {

        public static IQueryable<Stack> OrderStackListDataBy(this IQueryable<Stack> data, StackListDataFilter option)
        {
            switch (option.OrderBy)
            {
                case StackListOrderByOptions.IdDesc:
                    data = data.OrderByDescending(x => x.Id);
                    break;
                case StackListOrderByOptions.Id:
                    data = data.OrderBy(x => x.Id);
                    break;
                case StackListOrderByOptions.NameDesc:
                    data = data.OrderByDescending(x => x.Name);
                    break;
                case StackListOrderByOptions.Name:
                    data = data.OrderBy(x => x.Name);
                    break;
            }
            return data;
        }
    }
}